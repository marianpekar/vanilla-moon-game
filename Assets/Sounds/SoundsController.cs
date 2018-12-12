using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour {

	public AudioClip[] sounds;
	public AudioSource laughing;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetSfxVolume();
		laughing.volume = PlayerPrefsManager.GetSfxVolume() * 5f;
	}

	public void PlayEngineIgnition() {
		audioSource.clip = sounds[0];
		audioSource.Play();
	}

	public void PlayLowFuel() {
		audioSource.clip = sounds[1];
		audioSource.Play();
	}

	public void PlayConePick() {
		audioSource.clip = sounds[2];
		audioSource.Play();
	}

	public void PlayFuelTankPick() {
		audioSource.clip = sounds[3];
		audioSource.Play();
	}

	public void PlayAdditivesPick() {
		audioSource.clip = sounds[4];
		audioSource.Play();
	}

	public void PlaySpeedBoosterPick() {
		audioSource.clip = sounds[5];
		audioSource.Play();
	}

	public void PlayCursedConePicked() {
		laughing.Play();
	}

	public void ChangeSfxVolume() {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetSfxVolume();
	}

	public void ChangeLaughingVolume() {
		laughing.volume = PlayerPrefsManager.GetSfxVolume() * 5f;
	} 
}
