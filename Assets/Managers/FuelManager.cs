using UnityEngine;
using System.Collections;

public class FuelManager : MonoBehaviour {

	private static float maxFuel = 100; 
	private static float fuel = 100;
	private static UIFuelMeter uiFuelMeter;
	private static GameManager gameManager;
	private static PlayerController playerController;

	void Start() {
		uiFuelMeter = FindObjectOfType<UIFuelMeter>();
		gameManager = FindObjectOfType<GameManager>();
		playerController = FindObjectOfType<PlayerController>();
	}

	public static void AddFuel(float amount) {
		if(GetFuel() + amount < maxFuel) {
			fuel += amount;
		} else {
			fuel = maxFuel;
		}

		UpdateUI();
	}

	public static void ConsumeFuel(float amount) {
		if(GetFuel() > 0) {
			fuel-=amount * Time.deltaTime;
		} else if (GetFuel() <= 0 && playerController.GetZ() <= 0) {
			gameManager.OutOfFuel();
		}

		UpdateUI();
	}

	public static void Reset() {
		fuel = maxFuel;
		UpdateUI();
	}

	public static float GetFuel() {
		return fuel;
	}

	public static float GetMaxFuel() {
		return maxFuel;
	}

	static void UpdateUI() {
		uiFuelMeter.UpdateValue();
	}

}
