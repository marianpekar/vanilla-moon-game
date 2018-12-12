using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int fuelTanksCount;
	public int conesCount;
	public int coneBoxesCount;
	public Spawner spawner;

	public enum GAMEMODE {
		Freestyle,
		Cursed,
		ThreeMinutes,
		SixMinutes,
		TwelveMinutes
	};

	private GAMEMODE mode;
	private CameraController cameraController;
	private PlayerController playerController;
	private UIController uiController;
	private UIGameModesController uiGameModesController;
	private MusicManager musicManager;
	private EngineSoundController engineSoundController;
	private SoundsController soundsController;
	private int gameModeIndex = 1;
	private TimerController timeController;
	private HighScoreManager highScoreManager;

	void Start() {
		cameraController = FindObjectOfType<CameraController>();
		playerController = FindObjectOfType<PlayerController>();
		uiController = FindObjectOfType<UIController>();
		musicManager = FindObjectOfType<MusicManager>();
		engineSoundController = FindObjectOfType<EngineSoundController>();
		soundsController = FindObjectOfType<SoundsController>();
		uiGameModesController = FindObjectOfType<UIGameModesController>();
		uiGameModesController.SwitchMode(gameModeIndex);
		timeController = FindObjectOfType<TimerController>();
		highScoreManager = FindObjectOfType<HighScoreManager>();

		for(int i = 0; i < coneBoxesCount; i++) {
			spawner.SpawnConeBox();
		}

		for(int i = 0; i < conesCount; i++) {
			spawner.SpawnCone();
		}

		for(int i = 0; i < fuelTanksCount; i++) {
			spawner.SpawnFuel();
		}

		spawner.SpawnAdditives();
		spawner.SpawnSpeedBooster();
		spawner.SpawnCursedCone();

		ShowCursedCone(false);
		ShowAdditives(false);
		ShowCones(false);
		ShowTanks(false);
		musicManager.PlayMenuMusic();
	}

	void ResetStates() {
		ScoreManager.Reset();
		FuelManager.Reset();
	}

	void ShowSpeedBooster(bool state) {
		SpeedBooster speedBooster = FindObjectOfType<SpeedBooster>();
		speedBooster.Show(state);
		speedBooster.ChangePosition();
	}

	void ShowAdditives(bool state) {
		Additives additives = FindObjectOfType<Additives>();
		additives.Show(state);
		additives.ChangePosition();
	}

	void ShowCursedCone(bool state) {
		CursedCone cursedCone = FindObjectOfType<CursedCone>();
		cursedCone.Show(state);
		cursedCone.ChangePosition();
	}

	void ShowTanks(bool state) {
		FuelTank[] fuelTanks = FindObjectsOfType<FuelTank>();

		foreach(FuelTank fuelTank in fuelTanks) {
			fuelTank.Show(state);
			fuelTank.ChangePosition();
		}
	}

	void ShowCones(bool state) {
		Coin[] cones = FindObjectsOfType<Coin>();

		foreach(Coin cone in cones) {
			cone.Show(state);
			cone.ChangePosition();
		}
	}

	public void SelectGameMode() {
		uiController.ShowMainMenu(false);
		uiController.ShowGameModeMenu(true);
	}

	public void SwitchGameMode(int i) {
		gameModeIndex += i;

		int enumCount = System.Enum.GetValues(typeof(GAMEMODE)).Length;
		if (gameModeIndex > enumCount) {
			gameModeIndex = 1;
		} else if (gameModeIndex < 1) {
			gameModeIndex = enumCount;
		}

		//Debug.Log(gameModeIndex);

		uiGameModesController.SwitchMode(gameModeIndex);

		switch(gameModeIndex) {
			case 1:
				mode = GAMEMODE.Freestyle;
				break;
			case 2:
				mode = GAMEMODE.Cursed;
				break;
			case 3:
				mode = GAMEMODE.ThreeMinutes;
				break;
			case 4:
				mode = GAMEMODE.SixMinutes;
				break;
			case 5:
				mode = GAMEMODE.TwelveMinutes;
				break;
		}
	}

	public void PlayGame() {
		musicManager.StopMusic();
		cameraController.SetCameraAtGamePosition(true);
		playerController.EnableControlls(true);
		uiController.ShowGameGUI(true);
		soundsController.PlayEngineIgnition();
		engineSoundController.PlayEngineSound();
		uiController.ShowGameModeMenu(false);

		if(mode == GAMEMODE.Freestyle) {
			playerController.SetFuelConsuptions(GetFuelConsumpionByGameMode(mode));
			ShowCones(true);
			ShowTanks(true);
			ShowAdditives(true);
			ShowSpeedBooster(true);
			musicManager.PlayGameMusic();
		} else if (mode == GAMEMODE.Cursed) {
			playerController.SetFuelConsuptions(GetFuelConsumpionByGameMode(mode));
			ShowCones(true);
			ShowCursedCone(true);
			musicManager.PlayGameMusic();
		} else if (mode == GAMEMODE.ThreeMinutes) {
			playerController.SetFuelConsuptions(GetFuelConsumpionByGameMode(mode));
			ShowCones(true);
			ShowTanks(true);
			ShowAdditives(true);
			ShowSpeedBooster(true);
			timeController.SetTime(181);
			uiController.ShowTimer(true);
			timeController.StartCountdown();
			musicManager.PlayGameMusic();
		} else if (mode == GAMEMODE.SixMinutes) {
			playerController.SetFuelConsuptions(GetFuelConsumpionByGameMode(mode));
			ShowCones(true);
			ShowTanks(true);
			ShowAdditives(true);
			ShowSpeedBooster(true);
			timeController.SetTime(361);
			uiController.ShowTimer(true);
			timeController.StartCountdown();
			musicManager.PlayGameMusic();
		} else if (mode == GAMEMODE.TwelveMinutes) {
			playerController.SetFuelConsuptions(GetFuelConsumpionByGameMode(mode));
			ShowCones(true);
			ShowAdditives(true);
			ShowTanks(true);
			ShowSpeedBooster(true);
			timeController.SetTime(721);
			uiController.ShowTimer(true);
			timeController.StartCountdown();
			musicManager.PlayGameMusic();
		}
	}

	public void PauseTimer() {
		timeController.StopCountdown();
	}

	public void ResumeTimer() {
		timeController.StartCountdown();
	}

	public void BackToMainMenu() {
		engineSoundController.StopEngineSound();
		ResetStates();
		cameraController.SetCameraAtGamePosition(false);
		playerController.EnableControlls(false);
		uiController.ShowMainMenu(true);
		uiController.ShowGameGUI(false);
		uiController.ShowLostPrompt(false);
		ShowMainMenuPrompt(false);
		ShowCones(false);
		ShowTanks(false);
		ShowCursedCone(false);
		ShowAdditives(false);
		ShowSpeedBooster(false);
		musicManager.PlayMenuMusic();
		timeController.StopCountdown();
		uiController.ShowTimer(false);
	}

	public void ShowMainMenuPrompt(bool state) {
		uiController.ShowMainMenuPrompt(state);
	}

	public void OutOfFuel() {
		if(highScoreManager.CheckScore(ScoreManager.GetScore())) {
			uiController.SetLostMessage("You're run out of fuel but got the highest score in " + GetModeName(mode));
		} else {
			uiController.SetLostMessage("You're run out of fuel"); 
		}
		timeController.StopCountdown();
		ShowLostPrompt();
		DisablePlayerController();
	}

	public void OutOfTime() {
		if(highScoreManager.CheckScore(ScoreManager.GetScore())) {
			uiController.SetLostMessage("You're run out of time but got the highest score in " + GetModeName(mode));
		} else {
			uiController.SetLostMessage("You're run out of time"); 
		}
		timeController.StopCountdown();
		ShowLostPrompt();
		DisablePlayerController();
	}

	private void ShowLostPrompt() {
		uiController.ShowLostPrompt(true);
	}

	private void DisablePlayerController() {
		playerController.EnableControlls(false);
		engineSoundController.StopEngineSound();
	}

	public GAMEMODE GetGameMode() {
		return mode;
	}

	public float GetFuelConsumpionByGameMode(GAMEMODE mode) {
		if(mode == GAMEMODE.Freestyle) { return 2f; }
		if(mode == GAMEMODE.Cursed) { return 0; }
		if(mode == GAMEMODE.ThreeMinutes) { return 1.2f; }
		if(mode == GAMEMODE.SixMinutes) { return 2f; }
		if(mode == GAMEMODE.TwelveMinutes) { return 2.25f;}

		return 2; 
	}

	private string GetModeName(GAMEMODE mode) {
		if(mode == GAMEMODE.Freestyle) { return "Freestyle"; }
		if(mode == GAMEMODE.Cursed) { return "Cursed"; }
		if(mode == GAMEMODE.ThreeMinutes) { return "Three Minutes"; }
		if(mode == GAMEMODE.SixMinutes) { return "Six Minutes"; }
		if(mode == GAMEMODE.TwelveMinutes) { return "Twelve Minutes"; }

		return "";
	}

	public void QuitGame() {
		Application.Quit();
	}
}
