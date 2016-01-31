using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
	public int moveSpdX=5;
	public int moveSpdY=5;

	public int moveDirectionX = 0;
	public int moveDirectionY = 0;

	public float fullStam = 100.0f;
	public float stamConsume = 0.5f;
	public float stamRecover = 0.75f;
	public float currStam = 100.0f;

	public UIProgressBar stamProgress;

	public AudioClip clips;

	void Start(){

	}

	// Update is called once per frame
	void Update () {
		if(currStam>0){
			if(Input.GetKeyDown(KeyCode.A)){
				moveDirectionX = -1;
			}
			if(Input.GetKeyUp(KeyCode.A) && moveDirectionX!=1){
				moveDirectionX = 0;
			}

			if(Input.GetKeyDown(KeyCode.S)){
				moveDirectionY = -1;
			}
			if(Input.GetKeyUp(KeyCode.S) && moveDirectionY!=1 ){
				moveDirectionY = 0;
			}

			if(Input.GetKeyDown(KeyCode.D)){
				moveDirectionX = 1;
			}
			if(Input.GetKeyUp(KeyCode.D) && moveDirectionX!=-1){
				moveDirectionX = 0;
			}

			if(Input.GetKeyDown(KeyCode.W)){
				moveDirectionY = 1;
			}
			if(Input.GetKeyUp(KeyCode.W) && moveDirectionY!=-1){
				moveDirectionY = 0;
			}
		}else{
			moveDirectionX = 0;
			moveDirectionY = 0;
		}

		UpdatePosition();
	}

	void UpdatePosition(){
		if(moveDirectionX!=0 || moveDirectionY!=0){
			transform.localPosition += new Vector3(moveSpdX*moveDirectionX,  moveSpdY*moveDirectionY, 0);
			UpdateStam(true);
		}else{
			UpdateStam(false);
		}
	}

	void UpdateStam(bool isConsume){
		if(isConsume){
			currStam-=stamConsume;
		}else{
			currStam+=stamRecover;
		}
		if(currStam<0){
			currStam=0;
		}
		if(currStam>fullStam){
			currStam=fullStam;
		}
		UpdateStamProgress();
	}

	void UpdateStamProgress(){
		stamProgress.value = currStam/fullStam;
	}
}
