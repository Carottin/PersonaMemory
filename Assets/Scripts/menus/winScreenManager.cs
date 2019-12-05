using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winScreenManager : MonoBehaviour {
	public Text scoreText; 

	void Start(){
		// Get the last game score
		float score = PlayerPrefsX.GetFloatList ("highScore") [(PlayerPrefsX.GetFloatList ("highScore").Count) - 1];
		scoreText.text = Mathf.Floor (score / 60).ToString("00") + ":" + (score  % 60).ToString("00");
	}

	// To load menu
	public void loadMenu(){
		GameObject.Find("musicManager").GetComponent<musicPlayer> ().clickSound.Play ();
		SceneManager.LoadScene ("menu");
	}
}
