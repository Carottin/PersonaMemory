using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {
	private AudioSource _audioSource;
	public Canvas alertDialog; // canvas for alert dialog

	void Start(){
		// Start playing music
		GameObject.FindGameObjectWithTag("Music").GetComponent<musicPlayer>().PlayMusic();
		_audioSource = GameObject.FindGameObjectWithTag ("Music").GetComponent<musicPlayer> ()._audioSource;

		// Hide alert dialog
		alertDialog.scaleFactor = 0;
	}


	public void triggerMenuManager(int i){
		switch (i) {
		default:
		// Click on play
		case(0):
			GameObject.Find("musicManager").GetComponent<musicPlayer> ().clickSound.Play ();
			SceneManager.LoadScene ("memoryLevel");
				break;
		// click on highscore
		case(1):
			GameObject.Find("musicManager").GetComponent<musicPlayer> ().clickSound2.Play ();
			SceneManager.LoadScene ("highScores");
			break;
		// Click on quit
		case(2):
			showAlertDialog ();
				break;
		}
	}

	// To show alert dialog
	public void showAlertDialog(){
		alertDialog.scaleFactor = 1;
		GameObject.Find("musicManager").GetComponent<musicPlayer> ().clickSound2.Play ();
	}

	// To hide alert dialog
	public void hideAlertDialog(){
		alertDialog.scaleFactor = 0;
		GameObject.Find("musicManager").GetComponent<musicPlayer> ().clickSound2.Play ();
	}

	// To quit game
	public void quitGame(){
		Application.Quit ();
	}
}
