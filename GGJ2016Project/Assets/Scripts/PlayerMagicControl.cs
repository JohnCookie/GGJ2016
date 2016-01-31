using UnityEngine;
using System.Collections;

public class PlayerMagicControl : MonoBehaviour {
	public KeyCode ElementA;
	public KeyCode ElementB;
	public KeyCode ElementC;
	public KeyCode ElementD;
	public KeyCode ElementConfirm;
	public int team = 0;

	public string currMagic = "";
	public UILabel m_labelMagicName;
	public TweenAlpha magicTweenAlpha;
	public TweenPosition magicTweenPosition;

	public PlayerStatus enermyTarget;

	public UISprite[] spritArr;
	public Transform shootBeginPoint;
	public GameObject shootObjPrefab;

	public Transform[] summonMonsterPos;
	public GameObject[] summonedMonster;
	public GameObject monsterPrefab;

	public Animator m_anim;
	// Use this for initialization
	void Start () {
		refreshSpritElements();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameCore.currStatus == GameStatus.Normal) {
			if (currMagic.Length < Constant.Max_Magic_Length) {
				if (Input.GetKeyUp (ElementA)) {
					currMagic += "A";
					GetComponent<PlayerStatus> ().spellMana ();
				}

				if (Input.GetKeyUp (ElementB)) {
					currMagic += "B";
					GetComponent<PlayerStatus> ().spellMana ();
				}

				if (Input.GetKeyUp (ElementC)) {
					currMagic += "C";
					GetComponent<PlayerStatus> ().spellMana ();
				}

				if (Input.GetKeyUp (ElementD)) {
					currMagic += "D";
					GetComponent<PlayerStatus> ().spellMana ();
				}
			}

			if (Input.GetKeyUp (ElementConfirm)) {
				castMagic ();
			}

			refreshSpritElements ();
		}
	}

	void castMagic(){
		if(CastUtil.getInstance().castNameDict.ContainsKey(currMagic)){
			if(GetComponent<PlayerStatus>().currMana>= CastUtil.getInstance().castNameDict[currMagic].consume){
				m_labelMagicName.text = CastUtil.getInstance().castNameDict[currMagic].name;
				GetComponent<PlayerStatus>().consumeMana(CastUtil.getInstance().castNameDict[currMagic].consume);
				switch(CastUtil.getInstance().castNameDict[currMagic].type){
				case MagicType.Shoot:
					if(!castShootObj(CastUtil.getInstance().castNameDict[currMagic])){
						m_labelMagicName.text = "Oh No! Anti Magic";
						GetComponent<PlayerStatus>().clearMana();
						enermyTarget.fullMana();
						AudioControler.getInstance().playFail();
					}else{
						AudioControler.getInstance().playShoot();
					}
					break;
				case MagicType.Summon:
					if(!summonMonster(CastUtil.getInstance().castNameDict[currMagic].element)){
						m_labelMagicName.text = "Failed";
						AudioControler.getInstance().playFail();
					}else{
						AudioControler.getInstance().playMagic();
					}
					break;
				case MagicType.Guard:
					GetComponent<PlayerStatus>().changeGuard(CastUtil.getInstance().castNameDict[currMagic].element);
					AudioControler.getInstance().playMagic();
					break;
				case MagicType.AntiMagic:
					enermyTarget.getDebuff(1);
					AudioControler.getInstance().playMagic();
					break;
				case MagicType.CancelMagic:
					enermyTarget.removeGuard();
					AudioControler.getInstance().playMagic();
					break;
				}
			}else{
				m_labelMagicName.text= "Mana not enough";
				AudioControler.getInstance().playFail();
				return;
			}
		}else{
			AudioControler.getInstance().playFail();
			m_labelMagicName.text = "Failed";
		}

		currMagic = "";
		showMagicName();
		m_anim.Play("WizardAnim");
	}

	void showMagicName(){
		magicTweenAlpha.enabled = true;
		magicTweenPosition.enabled = true;
		magicTweenAlpha.ResetToBeginning();
		magicTweenPosition.ResetToBeginning();
		magicTweenPosition.SetOnFinished(()=>{
			m_labelMagicName.text = "";
		});
		magicTweenAlpha.PlayForward();
		magicTweenPosition.PlayForward();
	}

	bool castShootObj(MagicData magic){
		if(GetComponent<PlayerStatus>().currDebuff>0){
			return false;
		}else{
			GameObject shoot = Instantiate(shootObjPrefab) as GameObject;
			shoot.transform.parent = shootBeginPoint;
			shoot.transform.localPosition = Vector3.zero;
			shoot.transform.localScale = Vector3.one;
			shoot.GetComponent<ShootObj>().InitShootObj(team, enermyTarget.transform.position, 1.5f, magic.damage, magic.element);
			return true;
		}
	}

	bool summonMonster(int summonType){
		int index = -1;
		for(int i=0;i<summonedMonster.Length;i++){
			if(summonedMonster[i]==null){
				index = i;
				break;
			}
		}
		if(index>=0){
			GameObject monster = Instantiate(monsterPrefab) as GameObject;
			monster.transform.parent = summonMonsterPos[index];
			monster.transform.localPosition = Vector3.zero;
			monster.transform.localScale = Vector3.one;

			monster.GetComponent<MonsterObj>().Init(index, this, enermyTarget, team, summonType);
			summonedMonster[index]=monster;
			return true;
		}else{
			return false;
		}

	}

	public void removeMonster(int index){
		summonedMonster[index] = null;
	}

	void refreshSpritElements(){
		for(int i=0; i<spritArr.Length; i++){
			if(i<currMagic.Length){
				spritArr[i].enabled=true;
				switch(currMagic.ToCharArray()[i]){
				case 'A':
					spritArr[i].spriteName = "fire";
					break;
				case 'B':
					spritArr[i].spriteName = "ice";
					break;
				case 'C':
					spritArr[i].spriteName = "thunder";
					break;
				case 'D':
					spritArr[i].spriteName = "earth";
					break;
				default:
					spritArr[i].spriteName = "fire";
					break;
				}
			}else{
				spritArr[i].enabled=false;
			}
		}
	}
}
