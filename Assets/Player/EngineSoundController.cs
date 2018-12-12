using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundController : MonoBehaviour {

	private AudioSource audioSource;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		playerController = FindObjectOfType<PlayerController>();
	}
	
	public void PlayEngineSound() {
		audioSource.Play();
	}

	public void StopEngineSound() {
		audioSource.Stop();
	}

	void Update() {
		if (PlayerPrefsManager.GetSfxVolume() > 0f) {
			audioSource.volume = PlayerPrefsManager.GetSfxVolume() + Mathf.Abs(playerController.GetZ()) / 10f;
			audioSource.pitch = 0.5f + Mathf.Abs(playerController.GetZ()) + (playerController.GetSpeed() / 100);
		}
	}

	public void ChangeEngineSoundVolume() {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetSfxVolume();
	}
}
