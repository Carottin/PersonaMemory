using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class buttonScriptHighScore : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {

	public Text theText;

	// pointer enter button
	public void OnPointerEnter(PointerEventData eventData)
	{
		// Changer color and play sound
		theText.color = Color.red; 
		GameObject.Find("musicManager").GetComponent<musicPlayer> ().hoverSound.Play ();
	}

	// Pointer exit button
	public void OnPointerExit(PointerEventData eventData)
	{
		// Change color
		theText.color = Color.white; //Or however you do your color
	}

	// Button is clicked
	public void OnPointerDown(PointerEventData eventData){
		// Change color
		theText.color = new Color (150 / 255f, 0, 0);
	}
}
