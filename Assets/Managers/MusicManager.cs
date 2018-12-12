using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip[] music;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMusicVolume();
	}
	
	public void PlayMenuMusic() {
		audioSource.clip = music[0];
		audioSource.Play();
	}

	public void PlayGameMusic() {
		audioSource.clip = music[1];
		audioSource.Play();
	}

	public void StopMusic() {
		audioSource.Stop();
	}

	public void ChangeMusicVolume() {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMusicVolume();
	}
}
