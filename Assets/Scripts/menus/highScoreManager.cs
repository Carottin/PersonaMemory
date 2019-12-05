using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class highScoreManager : MonoBehaviour {
	public float[] highScores;

	public Text score1;
	public Text score2;
	public Text score3;
	public Text score4;
	public Text score5;
	public Text score6;
	public Text score7;
	public Text score8;
	public Text score9;


	void Start () {
		// Play menu music
		GameObject.FindGameObjectWithTag("Music").GetComponent<musicPlayer>().PlayMusic();
		highScores = PlayerPrefsX.GetFloatArray("highScore");
		Array.Sort (highScores);

		// Set text for highscores
		if(highScores.Length > 0)	
			score1.text = "#1 " + Mathf.Floor (highScores [0] / 60).ToString("00") + ":" + (highScores [0]  % 60).ToString("00");
		if(highScores.Length > 1)	
			score2.text = "#2 " +Mathf.Floor (highScores [1] / 60).ToString("00") + ":" + (highScores [1]  % 60).ToString("00");
		if(highScores.Length > 2)	
			score3.text = "#3 " +Mathf.Floor (highScores [2] / 60).ToString("00") + ":" + (highScores [2]  % 60).ToString("00");
		if(highScores.Length > 3)	
			score4.text = "#4 " +Mathf.Floor (highScores [3] / 60).ToString("00") + ":" + (highScores [3]  % 60).ToString("00");
		if(highScores.Length > 4)	
			score5.text = "#5 " +Mathf.Floor (highScores [4] / 60).ToString("00") + ":" + (highScores [4]  % 60).ToString("00");
		if(highScores.Length > 5)	
			score6.text = "#6 " +Mathf.Floor (highScores [5] / 60).ToString("00") + ":" + (highScores [5]  % 60).ToString("00");
		if(highScores.Length > 6)	
			score7.text = "#7 " +Mathf.Floor (highScores [6] / 60).ToString("00") + ":" + (highScores [6]  % 60).ToString("00");
		if(highScores.Length > 7)	
			score8.text = "#8 " +Mathf.Floor (highScores [7] / 60).ToString("00") + ":" + (highScores [7]  % 60).ToString("00");
		if(highScores.Length > 8)	
			score9.text = "#9 " +Mathf.Floor (highScores [8] / 60).ToString("00") + ":" + (highScores [8]  % 60).ToString("00");
		
	}

	// To load menu screen
	public void loadMenu(){
		GameObject.Find("musicManager").GetComponent<musicPlayer> ().clickSound2.Play ();
		SceneManager.LoadScene ("menu");
	}
}
