using UnityEngine;
using System.Collections;

public class AudioControler : MonoBehaviour
{
	public AudioSource m_AudioMgr;
	public AudioSource m_effectMgr;
	public AudioClip m_clipBgm;
	public AudioClip m_clipShoot;
	public AudioClip m_clipOtherMagic;
	public AudioClip m_clipDie;
	public AudioClip m_clipFail;

	private static AudioControler _instance;
	private AudioControler(){
	}
	public static AudioControler getInstance(){
		if(_instance==null){
			_instance=GameObject.Find("AudioMgr").GetComponent<AudioControler>();
		}
		return _instance;
	}

	public void playBGM(){
		m_AudioMgr.loop=true;
		m_AudioMgr.clip=m_clipBgm;
		m_AudioMgr.volume=2;
		m_AudioMgr.Play();
	}

	public void playShoot(){
		m_effectMgr.clip=m_clipShoot;
		m_effectMgr.volume=4;
		m_effectMgr.loop=false;
		m_effectMgr.PlayOneShot(m_clipShoot);
	}

	public void playMagic(){
		m_effectMgr.clip=m_clipOtherMagic;
		m_effectMgr.volume=4;
		m_effectMgr.loop=false;
		m_effectMgr.PlayOneShot(m_clipOtherMagic);
	}

	public void playDie(){
		m_effectMgr.clip=m_clipDie;
		m_effectMgr.volume=4;
		m_effectMgr.loop=false;
		m_effectMgr.PlayOneShot(m_clipDie);
	}

	public void playFail(){
		m_effectMgr.clip=m_clipFail;
		m_effectMgr.volume=4;
		m_effectMgr.loop=false;
		m_effectMgr.PlayOneShot(m_clipFail);
	}
}

