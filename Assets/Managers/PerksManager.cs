using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerksManager : MonoBehaviour {

	private PlayerController playerController;
	private UIController uiController;

	private float originalFuelConsumption;
	private float originalSpeed;

	void Start() {
		playerController = FindObjectOfType<PlayerController>();
		uiController = FindObjectOfType<UIController>();
	}

	public  void ActivateAdditives() {
		uiController.ShowPerkAdditives(true);
		originalFuelConsumption = playerController.GetFuelConsumption();
		playerController.SetFuelConsuptions(originalFuelConsumption / 2);
		Invoke("BackToOriginalFuelConsumption",30);
	}

	private void BackToOriginalFuelConsumption() {
		uiController.ShowPerkAdditives(false);
		playerController.SetFuelConsuptions(originalFuelConsumption);
		Additives additives = FindObjectOfType<Additives>();
		additives.Show(true);
	}

	public void BoostSpeed() {
		uiController.ShowPerkSpeedbooster(true);
		originalSpeed = playerController.GetSpeed();
		playerController.SetSpeed(originalSpeed * 1.5f);
		Invoke("BackToOriginalSpeed", 10f);
	}

	private void BackToOriginalSpeed() {
		uiController.ShowPerkSpeedbooster(false);
		playerController.SetSpeed(originalSpeed);
		SpeedBooster speedBooster = FindObjectOfType<SpeedBooster>();
		speedBooster.Show(true);
	}
}
