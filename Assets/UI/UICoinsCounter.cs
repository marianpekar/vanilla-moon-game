using UnityEngine;
using UnityEngine.UI;

public class UICoinsCounter : MonoBehaviour {

	private Text text;

	void Start() {
		text = GetComponent<Text>();
	}

	public void UpdateCounter () {
		text.text = "x " + ScoreManager.GetScore().ToString();
	}
}
