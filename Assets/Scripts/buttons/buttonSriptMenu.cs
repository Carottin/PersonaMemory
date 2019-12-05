using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class buttonSriptMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {

	public Text theText;

	// Pointer enter button
	public void OnPointerEnter(PointerEventData eventData)
	{
		// Change color and play sound
		theText.color = Color.red; 
		GameObject.Find("musicManager").GetComponent<musicPlayer> ().hoverSound.Play ();
	}

	// Pointer exit button
	public void OnPointerExit(PointerEventData eventData)
	{
		// Change color
		theText.color = Color.black; //Or however you do your color
	}

	// Button is clicked
	public void OnPointerDown(PointerEventData eventData){
		// change color
		theText.color = new Color (150 / 255f, 0, 0);
	}
}
