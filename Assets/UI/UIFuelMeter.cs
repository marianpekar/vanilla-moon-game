using UnityEngine;
using UnityEngine.UI;

public class UIFuelMeter : MonoBehaviour {

	public RectTransform arrow;
	public Image icon; 

	private bool beeped = false;
	private SoundsController soundsController;

	// Use this for initialization
	void Start () {
		UpdateValue();
		soundsController = FindObjectOfType<SoundsController>();
	}

	public void UpdateValue () {
		float angle = Mathf.Clamp(90f - (0.9f * FuelManager.GetFuel()),0f,90f);
		arrow.rotation = Quaternion.Euler(0f,0f,angle);
		if(FuelManager.GetFuel() < FuelManager.GetMaxFuel() / 5) {
			icon.color = Color.yellow;

			if(!beeped) {
				soundsController.PlayLowFuel();
				beeped = true;
			}

		} else {
			icon.color = Color.black;
			beeped = false;
		}
	}
}
