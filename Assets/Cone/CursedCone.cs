using UnityEngine;

public class CursedCone : MonoBehaviour {

	public float rotationSpeed;

	private SoundsController soundsController;
	private PlayerController playerController;
	private MusicManager musicManager;
	private MeshRenderer[] meshRenderers;

	void Start() {
		soundsController = FindObjectOfType<SoundsController>();
		playerController = FindObjectOfType<PlayerController>();
		musicManager = FindObjectOfType<MusicManager>();
	}

	void Update() {
		transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * rotationSpeed));
	}

	public void ChangePosition() {
		transform.position = Random.onUnitSphere * 89f;
		transform.LookAt(-Vector3.zero);
	}

	public void Show(bool state) {
		meshRenderers = GetComponentsInChildren<MeshRenderer>();

		foreach (MeshRenderer meshRenderer in meshRenderers) {
			meshRenderer.enabled = false;
		}

		GetComponent<SphereCollider>().enabled = state;
		meshRenderers[Random.Range(0,meshRenderers.Length)].enabled = state;
	}

	void OnTriggerEnter(Collider col) {
		if (col.GetComponent<PlayerController>()) {
			musicManager.StopMusic();
			soundsController.PlayCursedConePicked();
			playerController.SetFuelConsuptions(100);
			Show(false);
		} else {
			ChangePosition();
		}
	}

}
