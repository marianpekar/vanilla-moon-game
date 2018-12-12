using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

	private UIController uiController;
	private GameManager gameManager;
	private AudioSource audioSource;
	private bool ticking;

	[SerializeField]
	private int time;

	void Start() {
		uiController = FindObjectOfType<UIController>();
		gameManager = FindObjectOfType<GameManager>();
		audioSource = GetComponent<AudioSource>();
	}

	public void ChangeTickingSoundVolume() {
		audioSource.volume = PlayerPrefsManager.GetSfxVolume();
	}

	public void SetTime (int seconds) {
		time = seconds;
	}
	
	// Update is called once per frame
	private void Countdown () {
		time--;

		if (time > 0 && time <= 10) {
			audioSource.Play();
		} 

		if(time <= 0) {
			SetTime(0);
			gameManager.OutOfTime();
		}

		UpdateUI();
	}

	public void StartCountdown() {
		InvokeRepeating("Countdown",0.001f,1f);	
	}

	public void StopCountdown() {
		CancelInvoke("Countdown");
	}

	private void UpdateUI() {
		float minutes = Mathf.Floor(time / 60);
		float seconds = time % 60;

		string uiMinutes = minutes.ToString();
		string uiSeconds = seconds.ToString();

		if (uiSeconds.Length < 2) { 
			uiSeconds = "0" + uiSeconds;
		}

		if (uiMinutes.Length < 2) {
			uiMinutes = "0" + uiMinutes;
		}

		string uiTime = uiMinutes + ":" + uiSeconds;
		uiController.SetTimer(uiTime);
	}

	public int GetTime() {
		return time;
	}



}
