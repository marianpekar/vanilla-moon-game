using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	const string SFX_VOLUME = "sfx_volume";
	const string MUSIC_VOLUME = "music_volume";

	const string HIGHSCORE_FREESTYLE = "highscore_freestyle";
	const string HIGHSCORE_CURSED = "highscore_cursed";
	const string HIGHSCORE_THREE_MINUTES = "highscore_three_minutes";
	const string HIGHSCORE_SIX_MINUTES = "highscore_six_minutes";
	const string HIGHSCORE_TWELVE_MINUTES = "highscore_twelve_minutes";

	//high scores
	public static int GetHighScore(GameManager.GAMEMODE mode) {
		if(mode == GameManager.GAMEMODE.Freestyle) { return PlayerPrefs.GetInt(HIGHSCORE_FREESTYLE, 0); }
		if(mode == GameManager.GAMEMODE.Cursed) { return PlayerPrefs.GetInt(HIGHSCORE_CURSED, 0); }
		if(mode == GameManager.GAMEMODE.ThreeMinutes) { return PlayerPrefs.GetInt(HIGHSCORE_THREE_MINUTES, 0); }
		if(mode == GameManager.GAMEMODE.SixMinutes) { return PlayerPrefs.GetInt(HIGHSCORE_SIX_MINUTES, 0); }
		if(mode == GameManager.GAMEMODE.TwelveMinutes) { return PlayerPrefs.GetInt(HIGHSCORE_TWELVE_MINUTES, 0); }

		return 0;
	}

	public static void SetHighScore(GameManager.GAMEMODE mode, int score) {
		string prefMode = "";

		switch(mode) {
			case GameManager.GAMEMODE.Freestyle:
				prefMode = HIGHSCORE_FREESTYLE;
				break;
			case GameManager.GAMEMODE.Cursed:
				prefMode = HIGHSCORE_CURSED;
				break;
			case GameManager.GAMEMODE.ThreeMinutes:
				prefMode = HIGHSCORE_THREE_MINUTES;
				break;
			case GameManager.GAMEMODE.SixMinutes:
				prefMode = HIGHSCORE_SIX_MINUTES;
				break;
			case GameManager.GAMEMODE.TwelveMinutes:
				prefMode = HIGHSCORE_TWELVE_MINUTES;
				break;
		}

		PlayerPrefs.SetInt(prefMode, score);
	}

	//options
	public static void SetSfxVolume(float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(SFX_VOLUME, volume);
		}
	}

	public static float GetSfxVolume() {
		return PlayerPrefs.GetFloat(SFX_VOLUME, 0.08f);
	}


	public static void SetMusicVolume(float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(MUSIC_VOLUME, volume);
		}
	}

	public static float GetMusicVolume() {
		return PlayerPrefs.GetFloat(MUSIC_VOLUME, 1f);
	}
}
