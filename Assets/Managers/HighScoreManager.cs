using UnityEngine;

public class HighScoreManager : MonoBehaviour {

	private GameManager gameManager;

	void Start() {
		gameManager = FindObjectOfType<GameManager>();
	}

	public bool CheckScore(int score) {
		GameManager.GAMEMODE mode = gameManager.GetGameMode();

		if (score > PlayerPrefsManager.GetHighScore(mode)) {
			SetHightScore(mode, score);
			return true;
		}

		return false;
	}	

	private void SetHightScore(GameManager.GAMEMODE mode, int score) {
		PlayerPrefsManager.SetHighScore(mode, score);
	}
}
