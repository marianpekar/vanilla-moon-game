using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Additives : MonoBehaviour {

	public float rotationSpeed;

	private PerksManager perksManager;
	private SoundsController soundsController;

	void Start() {
		perksManager = FindObjectOfType<PerksManager>();
		soundsController = FindObjectOfType<SoundsController>();
	}

	void Update() {
		transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * rotationSpeed));
	}

	public void ChangePosition() {
		transform.position = Random.onUnitSphere * 91f;
		transform.LookAt(-Vector3.zero);
	}

	public void Show(bool state) {
		GetComponent<MeshRenderer>().enabled = state;
		GetComponent<SphereCollider>().enabled = state;
	}

	void OnTriggerEnter(Collider col) {
		if (col.GetComponent<PlayerController>()) {
			soundsController.PlayAdditivesPick();
			ChangePosition();
			perksManager.ActivateAdditives();
			Show(false);
		} else {
			ChangePosition();
		}
	}
}
