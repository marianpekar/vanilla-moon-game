using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private static int score;
	private static UICoinsCounter uiCoinsCounter;

	void Start() {
		uiCoinsCounter = GameObject.FindObjectOfType<UICoinsCounter>();
	}

	public static void AddPoints(int points) {
		score += points;
		uiCoinsCounter.UpdateCounter();
	}

	public static int GetScore() {
		return score;
	}

	public static void Reset() {
		score = 0;
		uiCoinsCounter.UpdateCounter();
	}

}
