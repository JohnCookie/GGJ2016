using UnityEngine;
using System.Collections;

public class MonsterObj : MonoBehaviour
{
	int index = 0;
	int team = 0;
	int type = 0;
	public float lifeTime = 9.0f;
	public float atkInterval = 2.0f;
	public int damage = 1;
	PlayerMagicControl master;
	PlayerStatus target;
	public GameObject shootObjPrefab;
	public UISprite mImg;

	public void Init(int mIndex, PlayerMagicControl mMaster, PlayerStatus mTarget,int mTeam, int mType){
		index = mIndex;
		master = mMaster;
		target = mTarget;
		team = mTeam;
		type = mType;

		if(team == 0){
			mImg.flip = UIBasicSprite.Flip.Horizontally;
		}else{
			mImg.flip = UIBasicSprite.Flip.Nothing;
		}

		switch(type){
		case 1:
			mImg.spriteName = "firemonster";
			break;
		case 2:
			mImg.spriteName = "icemonster";
			break;
		case 3:
			mImg.spriteName = "thundermonster";
			break;
		}
	}
		// Use this for initialization
		void Start ()
		{
			InvokeRepeating("dealDamage", atkInterval, atkInterval);
		}
	
		// Update is called once per frame
		void Update ()
		{
			lifeTime-=Time.deltaTime;
			if(lifeTime<=0){
				CancelInvoke("dealDamage");
				master.removeMonster(index);
				Destroy(gameObject);
			}
		}

	void dealDamage(){
		// target.getDamage(damage);
		castShootObj();
	}

	void castShootObj(){
		GameObject shoot = Instantiate(shootObjPrefab) as GameObject;
		shoot.transform.parent =transform.parent.transform;
		shoot.transform.localPosition = Vector3.zero;
		shoot.transform.localScale = Vector3.one;
		shoot.GetComponent<ShootObj>().InitShootObj(0, target.transform.position, 1.0f, Constant.Monster_Per_Atk, type);
	}
}

