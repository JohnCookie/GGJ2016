using UnityEngine;
using System.Collections;

public class Scene1 : MonoBehaviour
{
	public AudioSource m_audioPlayer;
	public AudioClip m_bgm;
	public TweenPosition logoTween;

	bool logoOK = false;

		// Use this for initialization
		void Start ()
		{
			logoOK=false;
			m_audioPlayer.loop=true;
			m_audioPlayer.clip=m_bgm;
			m_audioPlayer.volume=2;
			m_audioPlayer.Play();
		}
	
		// Update is called once per frame
		void Update ()
		{
			if(Input.GetKeyUp(KeyCode.Space)){
				if(logoOK){
					GoToNextScene();
				}else{
					logoTween.enabled = true;
					logoTween.ResetToBeginning();
					logoTween.delay=0.0f;
					logoTween.PlayForward();
				}
			}
		}

	public void GoToNextScene(){
		Application.LoadLevel(1);
	}

	public void logoAnimEnd(){
		logoOK=true;
	}
}

