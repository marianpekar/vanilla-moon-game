using UnityEngine;

public class Wheel : MonoBehaviour {

	public bool turnable;

	private float z, x;
	private float xAngle = 0;
	private PlayerController playerController;

	void Start() {
		playerController = GetComponentInParent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {
	   z = playerController.GetZ();
	   x = playerController.GetX();

		if(turnable) {
			TurnAndRotate(z, x);
		} else {
			Rotate(z);
		}
	}

	private void Rotate(float z) {
		if (z != 0f) {
			transform.localRotation = transform.localRotation * Quaternion.Euler(z * Time.deltaTime * 600f,transform.localRotation.y,transform.localRotation.z);
		}
	}

	private void TurnAndRotate(float z, float x) {
		xAngle += z * Time.deltaTime * 600f;
		transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(transform.localRotation.x + xAngle,GetTurnDirection(x) * 28f, 0f),0.22f);
	}


	private float GetTurnDirection(float x) {
		if(x < 0f) {
			return -1f; 
		} else if (x > 0f) {
			return 1f;
		} else {
			return 0f;
		}
	}
}
