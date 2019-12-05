using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  

public class cardScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public static bool canPlayCard = true;
	public Button colorButton;


	[SerializeField]
	private int _state; 
	[SerializeField]
	private int _cardValue;
	[SerializeField]
	private bool _initialized = false;

	private Sprite _cardBack;
	private Sprite _cardFace;

	private GameObject _manager;

	void Start(){
		_state = 1; 
		_manager = GameObject.Find("gameManager"); // get the game manager
		colorButton = GetComponent<Button>();
	}



	public void setImage(){
		_cardBack = _manager.GetComponent<myGameManager> ().getCardBack (); // get backCard Image
		_cardFace = _manager.GetComponent<myGameManager> ().getCardFace (cardValue); // get faceCardImage; card value is set in game manager

		flipCard (); // set card hidden
	}

	public void flipCard(){
		// flip carde to show face
		if (_state == 0 && _manager.GetComponent<myGameManager> ().canPlay == true) {
			GameObject.Find("musicManager").GetComponent<musicPlayer> ().flipSound.Play ();
			_state = 1;
			if (colorButton != null) {
				var colors = colorButton.colors;
				colors.highlightedColor = Color.white;
				colorButton.colors = colors;
			}
		// flip carde to show back
		} else if (_state == 1 && _manager.GetComponent<myGameManager> ().canPlay == true) {
			_state = 0;
		}
		// sprite is back
		if (_state == 0 && canPlayCard) { 
			GetComponent<Image> ().sprite = _cardBack;
		} 
		// sprite is face
		else if (_state == 1 && canPlayCard) {
			GetComponent<Image> ().sprite = _cardFace;
		}

		// Check for match
		_manager.GetComponent<myGameManager> ().checkCards ();
	}

	public void check (){
		StartCoroutine (pause ()); 
	}

	// Wait before card is flipped over
	IEnumerator pause(){
		yield return new WaitForSeconds (1); // wait 1 second

		// Change card sprite
		if (_state == 0) { 
			GetComponent<Image> ().sprite = _cardBack;
		}
		else if (_state == 1) {
			GetComponent<Image> ().sprite = _cardFace;
		}

		// Player can play again
		canPlayCard = true;
		_manager.GetComponent<myGameManager> ().canPlay = true;
	}

	// Getter and setter for _cardValue
	public int cardValue {
		get { return _cardValue; }
		set { _cardValue = value; }
	}

	// Getter and setter for _state
	public int state {
		get { return _state; }
		set { _state = value; }
	}

	// Getter and setter for _initialized
	public bool initialized {
		get { return _initialized; }
		set { _initialized = value; }
	}

	// Pointer enter card
	public void OnPointerEnter(PointerEventData eventData)
	{
		// if the game is not on pause
		if (!(_manager.GetComponent<myGameManager> ().pause)) {
			GameObject.Find ("musicManager").GetComponent<musicPlayer> ().hoverSound.Play ();

			// Change color
			if (colorButton != null && _state == 0) {
				var colors = colorButton.colors;
				colors.highlightedColor = Color.red;
				colorButton.colors = colors;
			}
		}
	}

	// Pointer exit card
	public void OnPointerExit(PointerEventData eventData)
	{
		// if the game is not on pause
		if (!(_manager.GetComponent<myGameManager> ().pause)) {
			// Change color
			if (colorButton != null) {
				var colors = colorButton.colors;
				colors.highlightedColor = Color.white;
				colorButton.colors = colors;
			}
		}
	}


}
