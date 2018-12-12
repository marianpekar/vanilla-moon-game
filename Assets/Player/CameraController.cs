using UnityEngine;

public class CameraController : MonoBehaviour {

public GameObject target;
public GameObject mainMenuCameraPosition;
public GameObject highScoreCameraPosition;

private bool isCameraAtGamePosition = false;
private bool isCameraAtHighScorePosition = false;
private bool isCameraAtMainMenuPosition = true;

private PlayerController playerController;

	void Start() {
		playerController = GameObject.FindObjectOfType<PlayerController>();
	}

	void LateUpdate() {
		if(isCameraAtGamePosition) {
			float x = playerController.GetX();
			float z = playerController.GetZ();

			transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3 (x * 3f, 10.84f, -19.29f - z * 2f),1f); 
			transform.rotation = target.transform.rotation * Quaternion.Euler(15.088f,-x * 8f,0);
		} else if (isCameraAtMainMenuPosition) {
			transform.position = mainMenuCameraPosition.transform.position;
			transform.rotation = mainMenuCameraPosition.transform.rotation;
		} else if (isCameraAtHighScorePosition) {
			transform.position = highScoreCameraPosition.transform.position;
			transform.rotation = highScoreCameraPosition.transform.rotation;
		}
	}

	public void SetCameraAtGamePosition(bool state) {
		isCameraAtGamePosition = state;
	}	

	public void SetCameraAtHighScorePosition(bool state) {
		isCameraAtHighScorePosition = state;
	}	

	public void SetCameraAtMainMenuPosition(bool state) {
		isCameraAtMainMenuPosition = state;
	}

}



 