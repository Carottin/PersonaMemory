using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class myGameManager : MonoBehaviour {

	public Canvas alertDialog; // canvas for alert dialog
	public bool pause = false; // check if game on pause

	public Sprite[] cardsFace; // sprite array for cards' faces
	public Sprite cardBack; // sprite for card back
	public GameObject[] cards; // all cards in game

	public Text matchText; // text displaying how muck matches left

	public Text timeText; // text displaying time
	public float gameTime = 0; // variable for time
	public string minutes = "00";
	public string seconds = "00";

	private bool _init = false; // check if game is init
	private int _matches = 6; // number of matches left

	public  bool canPlay = true; // check if player can play

	void Start(){
		alertDialog.scaleFactor = 0; // hide alert dialog
	}

	// Update is called once per frame
	void Update () {
		if (!_init) {
			InitializeCards (); // initializer all the cards
		}

		// if not on pause start timer
		if (!pause) {
			gameTime += Time.deltaTime;
			minutes = Mathf.Floor (gameTime / 60).ToString ("00");
			seconds = (gameTime % 60).ToString ("00");
			timeText.text = minutes + ":" + seconds;
		}
	}

	// Initialize all the cards
	void InitializeCards(){
		for (int id = 0; id < 2; id++) {
			for (int i = 1; i < 7; i++) {
				
				bool hasBeenInitialized = false;
				int choice = 0;

				// Find a card that has not been initialized
				while (!hasBeenInitialized) {
					choice = Random.Range (0, cards.Length); // get random int
					// Ged random card and check if it's initialized
					hasBeenInitialized = !(cards[choice].GetComponent<cardScript>().initialized);
				}
				cards [choice].GetComponent<cardScript> ().cardValue = i; // set card value
				cards [choice].GetComponent<cardScript> ().initialized = true;  // set card has been initialized
			}
		}

		foreach (GameObject card in cards) 
			card.GetComponent<cardScript> ().setImage (); // set face image for all cards

		if (!_init)
			_init = true; // set all cards are init
	}

	public Sprite getCardBack(){
		return cardBack;
	}
	public Sprite getCardFace(int i){
		return cardsFace[i-1];
	}
		
	public void checkCards(){
		List<int> cardFlippedList = new List<int>(); // card flipped list

		for (int i = 0; i < cards.Length; i++) {
			if (cards [i].GetComponent<cardScript> ().state == 1) { // if card is flipped
				cardFlippedList.Add(i);	
			}
		}
		if (cardFlippedList.Count == 2) { // if 2 cards are flipped
			canPlay = false;
			cardComparison(cardFlippedList);// compare the 2 cards
		}
	}

	void cardComparison(List<int> list){
		cardScript.canPlayCard = false;

		int x = 0;

		// if the 2 flipped cards are the same
		if (cards [list[0]].GetComponent<cardScript> ().cardValue == cards [list[1]].GetComponent<cardScript> ().cardValue) {
			x = 2; // card are the same

			// Hide the cards
			(cards [list[0]]).transform.localScale = new Vector3(0,0,0);
			(cards [list[1]]).transform.localScale = new Vector3(0,0,0);

			GameObject.Find("musicManager").GetComponent<musicPlayer> ().matchSound.Play ();
			_matches--; // decrement left matches
			matchText.text = _matches.ToString();

			if (_matches == 0) { // game is over
				// Add highscore
				var highScores = new List<float>();
				highScores = PlayerPrefsX.GetFloatList("highScore");
				highScores.Add (gameTime);
				PlayerPrefsX.SetFloatArray ("highScore", highScores.ToArray());
				Debug.Log (((PlayerPrefsX.GetFloatArray("highScore")[0]).ToString()));

				// Load win scene
				SceneManager.LoadScene ("winScene");	
			}
		}

		for (int i = 0; i < list.Count; i++) {
			// if the the 2 cards are the same state = 2
			// Cards won't flip again
			// Else state = 0
			cards [list[i]].GetComponent<cardScript> ().state = x;
			cards [list [i]].GetComponent<cardScript> ().check (); 
		}
	}
	// To show alert dialog
	public void showAlertDialog(){
		alertDialog.scaleFactor = 1;
		GameObject.Find("musicManager").GetComponent<musicPlayer> ().clickSound2.Play ();
		pause = true;
	}

	// To hide alert dialog
	public void hideAlertDialog(){
		alertDialog.scaleFactor = 0;
		GameObject.Find("musicManager").GetComponent<musicPlayer> ().clickSound2.Play ();
		pause = false;
	}

	// To load menu
	public void loadMenu(){
		GameObject.Find("musicManager").GetComponent<musicPlayer> ().clickSound.Play ();
		SceneManager.LoadScene ("menu");
	}
}
