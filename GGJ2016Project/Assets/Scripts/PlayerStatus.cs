using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
	public int max_hp = 100;
	public int currHp = 100;

	public int currGuard = 0;

	public int currDebuff = 0;
	
	public UISprite m_spriteGuard;
	public UILabel m_labelHp;
	public UISprite m_spriteDebuff;

	public int max_mana = 250;
	public int currMana = 250;
	public UIProgressBar m_progress;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			if(Time.frameCount%2==0){
				updateManaProgress();
			}
		}

	public void getDamage(int damage){
		if(currHp - damage < 0){
			currHp = 0;
			GameCore.setWinner(GetComponent<PlayerMagicControl>().team==0?1:0);
		}else{
			currHp = currHp-damage;
		}
		m_labelHp.text = currHp.ToString();
	}

	public void changeGuard(int guardNum){
		currGuard = guardNum;
		m_spriteGuard.enabled=true;
		Invoke("removeGuard", Constant.Guard_Continue_Time);
	}
	public void removeGuard(){
		currGuard = 0;
		m_spriteGuard.enabled=false;
	}

	public void getDebuff(int debuffNum){
		currDebuff = debuffNum;
		m_spriteDebuff.enabled = true;
		Invoke("removeDebuff", Constant.Debuff_Continue_Time);
	}
	public void removeDebuff(){
		currDebuff = 0;
		m_spriteDebuff.enabled=false;
	}

	public void clearMana(){
		currMana = 0;
	}
	public void consumeMana(int num){
		currMana = (currMana-num<0?0:currMana-num);
	}
	public void spellMana(){
		currMana = (currMana-Constant.Spell_Mana_Comsume<0?0:currMana-Constant.Spell_Mana_Comsume);
	}

	public void updateManaProgress(){
		recoverMana();
		m_progress.value = (float)currMana/(float)max_mana;
	}
	void recoverMana(){
		if (string.IsNullOrEmpty (GetComponent<PlayerMagicControl> ().currMagic)) {
			currMana = (currMana + Constant.Standard_Mana_Recover_Speed > max_mana ? max_mana : currMana + Constant.Standard_Mana_Recover_Speed);
		} else {
			currMana = (currMana + Constant.Standard_Mana_Recover_Speed*3 > max_mana ? max_mana : currMana + Constant.Standard_Mana_Recover_Speed*3);
		}
	}
}

