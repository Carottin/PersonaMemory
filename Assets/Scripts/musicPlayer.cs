using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicPlayer : MonoBehaviour {
	
	public AudioSource _audioSource;

	// Sounds
	public AudioSource clickSound;
	public AudioSource clickSound2;
	public AudioSource hoverSound;
	public AudioSource flipSound;
	public AudioSource matchSound;

	// Singleton
	private static musicPlayer musicPlayerInstace;
	void Awake(){
		DontDestroyOnLoad (this);
		_audioSource = GetComponent<AudioSource>();

		if (musicPlayerInstace == null) {
			musicPlayerInstace = this;
		} else {
			DestroyObject(gameObject);
		}
	}
	// Method to play menu music
	public void PlayMusic()
	{
		if (_audioSource.isPlaying){ 
			return ; 
		}
		_audioSource.Play();
	}
	// Method to stop menu music
	public void StopMusic()
	{
		_audioSource.Stop();
	}

	// if game start stop playing menu music
	void Update(){
		if(SceneManager.GetActiveScene().name == "memoryLevel"){
			StopMusic ();
		}
	}
}
