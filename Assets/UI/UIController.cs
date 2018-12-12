using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject uiCoins;
	public GameObject uiFuelMeter;
	public GameObject uiMainMenu;
	public GameObject uiLostPrompt;
	public GameObject uiMainMenuPrompt;
	public GameObject uiAbout;
	public GameObject uiGameMenu;
	public GameObject uiTimer;
	public GameObject uiOptions;
	public Image uiOptionsButton;
	public Text uiLostMessage; 
	public GameObject uiHighScores;
	public Text highScores;
	public Image uiPerksAdditives;
	public Image uiPerksSpeedbooster;

	private Text[] uiOptionsTexts;
	private Image[] uiOptionsImages;
	private Image[] uiFuelMeterImages;
	private Image uiCoinImage;
	private Text uiCoinText;
	private Text[] uiMainMenuTexts;
	private Text[] uiLostPromptTexts;
	private Text[] uiMainMenuPromptTexts;
	private Text[] uiAboutTexts;
	private Button[] uiMainMenuButtons;
	private Text[] uiGameMenuTexts;
	private Button[] uiGameMenuButtons;
	private Text uiTimerText;
	private Text[] uiHighScoresTexts;

	private CameraController cameraController;

	void Start() {
		uiFuelMeterImages = uiFuelMeter.GetComponentsInChildren<Image>();
		uiMainMenuTexts = uiMainMenu.GetComponentsInChildren<Text>();
		uiCoinImage = uiCoins.GetComponentInChildren<Image>();
		uiCoinText = uiCoins.GetComponentInChildren<Text>();
		uiLostPromptTexts = uiLostPrompt.GetComponentsInChildren<Text>();
		uiMainMenuPromptTexts = uiMainMenuPrompt.GetComponentsInChildren<Text>();
		uiAboutTexts = uiAbout.GetComponentsInChildren<Text>();
		uiMainMenuButtons = uiMainMenu.GetComponentsInChildren<Button>();
		uiGameMenuTexts = uiGameMenu.GetComponentsInChildren<Text>();
		uiGameMenuButtons = uiGameMenu.GetComponentsInChildren<Button>();
		uiTimerText = uiTimer.GetComponent<Text>();
		uiOptionsTexts = uiOptions.GetComponentsInChildren<Text>();
		uiOptionsImages = uiOptions.GetComponentsInChildren<Image>();
		uiHighScoresTexts = uiHighScores.GetComponentsInChildren<Text>();
		cameraController = FindObjectOfType<CameraController>();
	}

	public void ShowPerkAdditives(bool state) {
		uiPerksAdditives.enabled = state;
	} 

	public void ShowPerkSpeedbooster(bool state) {
		uiPerksSpeedbooster.enabled = state;
	} 

	public void ToogleOptions() {
		foreach (Text uiOptionText in uiOptionsTexts) {
			bool state = uiOptionText.enabled;
			uiOptionText.enabled = !state;
		}

		foreach (Image uiOptionImage in uiOptionsImages) {
			bool state = uiOptionImage.enabled;
			uiOptionImage.enabled = !state;

			if (uiOptionImage.enabled) {
				uiOptionsButton.color = Color.grey;
			} else {
				uiOptionsButton.color = Color.white;
			}
		}
	}

	public void SetLostMessage(string message) {
		uiLostMessage.text = message;
	}

	public void ShowTimer(bool state) {
		uiTimerText.enabled = state;
	}

	public void SetTimer(string time) {
		uiTimerText.text = time;
	}

	public void ShowGameGUI(bool state) {
		foreach (Image uiFuelMeterImage in uiFuelMeterImages) {
			uiFuelMeterImage.enabled = state;

			uiCoinImage.enabled = state;
			uiCoinText.enabled = state;
		}
	}

	public void ShowMainMenu (bool state) {
		foreach (Text uiMainMenuText in uiMainMenuTexts) {
			uiMainMenuText.enabled = state;
		}

		foreach (Button uiMainMenuButton in uiMainMenuButtons) {
			uiMainMenuButton.interactable = state;
		}

		cameraController.SetCameraAtMainMenuPosition(state);

		if(state) {
			ShowPerkAdditives(false);
			ShowPerkSpeedbooster(false);
		}

	}

	public void ShowGameModeMenu(bool state) {
		foreach (Text uiGameMenuText in uiGameMenuTexts) {
			uiGameMenuText.enabled = state;
		}

		foreach (Button uiGameMenuButton in uiGameMenuButtons) {
			uiGameMenuButton.interactable = state;
		}
	}

	public void ShowAbout() {
		ShowMainMenu(false);

		foreach(Text uiAboutText in uiAboutTexts) {
			uiAboutText.enabled = true;
		}
	}

	public void HideAbout() {
		ShowMainMenu(true);

		foreach(Text uiAboutText in uiAboutTexts) {
			uiAboutText.enabled = false;
		}
	}

	public void ShowHighScores() {
		UpdateHighScoresUI();
		cameraController.SetCameraAtHighScorePosition(true);
		ShowMainMenu(false);

		foreach(Text uiHighScoreText in uiHighScoresTexts) {
			uiHighScoreText.enabled = true;
		}
	}

	public void HideHighScores() {
		cameraController.SetCameraAtHighScorePosition(false);
		ShowMainMenu(true);

		foreach(Text uiHighScoreText in uiHighScoresTexts) {
			uiHighScoreText.enabled = false;
		}
	}

	public void UpdateHighScoresUI() {
		string frestyle_highscore = PlayerPrefsManager.GetHighScore(GameManager.GAMEMODE.Freestyle).ToString();
		string cursed_highscore = PlayerPrefsManager.GetHighScore(GameManager.GAMEMODE.Cursed).ToString();
		string three_minutes_highscore = PlayerPrefsManager.GetHighScore(GameManager.GAMEMODE.ThreeMinutes).ToString();
		string six_minutes_highscore = PlayerPrefsManager.GetHighScore(GameManager.GAMEMODE.SixMinutes).ToString();
		string twelve_minutes_highscore = PlayerPrefsManager.GetHighScore(GameManager.GAMEMODE.TwelveMinutes).ToString();

		if (frestyle_highscore == "") { frestyle_highscore = "None"; }
		if (cursed_highscore == "") { cursed_highscore = "None"; }
		if (three_minutes_highscore == "") { three_minutes_highscore = "None"; }
		if (six_minutes_highscore == "") { six_minutes_highscore = "None"; }
		if (twelve_minutes_highscore == "") { twelve_minutes_highscore = "None"; }

		highScores.text = 
		"Freestyle: " + frestyle_highscore + " ICC\n" +
		"Cursed: " + cursed_highscore + " ICC\n" +
		"Three Minutes: " + three_minutes_highscore + " ICC\n" +
		"Six Minutes: " + six_minutes_highscore + " ICC\n" +
		"Twelve Minutes: " + twelve_minutes_highscore + " ICC\n";
	}


	public void ShowLostPrompt(bool state) {
		foreach(Text uiLostPromptText in uiLostPromptTexts) {
			uiLostPromptText.enabled = state;
		}
	}

	public void ShowMainMenuPrompt(bool state) {
		foreach(Text uiMainMenuPromptText in uiMainMenuPromptTexts) {
			uiMainMenuPromptText.enabled = state;
		}
	}

}
