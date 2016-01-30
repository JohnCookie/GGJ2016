using UnityEngine;
using System.Collections;

public class ShootObj : MonoBehaviour
{
	public int team = 0; // 0 belong to left, 1 belong to right
	public Vector3 targetPos;
	public Vector3 originPos;
	public float moveTime = 2;

	public int damage = 5;
	public float currTime = 0.0f;
	public int damageType;
		// Use this for initialization
		void Start ()
		{
	
		}

	public void InitShootObj(int team, Vector3 targetPos, float time, int damage, int damageType){
		this.originPos = transform.position;
		this.team = team;
		this.moveTime = time;
		this.targetPos = targetPos;
		this.damage = damage;
		this.currTime = 0.0f;
		this.damageType = damageType;
	}

		// Update is called once per frame
		void Update ()
		{
			transform.position = Vector3.Lerp(originPos, targetPos, currTime/moveTime);
			currTime+=Time.deltaTime;
		}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			if(other.GetComponent<PlayerStatus>().currGuard == damageType){
				damage = 0;
			}
			other.GetComponent<PlayerStatus>().getDamage(damage);
			Destroy(gameObject);
		}
	}

}

