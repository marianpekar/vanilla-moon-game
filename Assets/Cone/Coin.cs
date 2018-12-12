using UnityEngine;

public class Coin : MonoBehaviour {

	public float rotationSpeed;
	public int points;

	private SoundsController soundsController;

	void Start() {
		soundsController = FindObjectOfType<SoundsController>();
	}

	void Update() {
		transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * rotationSpeed));
	}

	public void ChangePosition() {
		transform.position = Random.onUnitSphere * 89f;
		transform.LookAt(-Vector3.zero);
	}

	public void Show(bool state) {
		GetComponent<MeshRenderer>().enabled = state;
		GetComponent<SphereCollider>().enabled = state;
	}

	void OnTriggerEnter(Collider col) {
		if (col.GetComponent<PlayerController>()) {
			soundsController.PlayConePick();
			ChangePosition();
			ScoreManager.AddPoints(points);
		} else {
			ChangePosition();
		}
	}

}
