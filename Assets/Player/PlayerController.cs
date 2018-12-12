using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float fuelConsumption;

	[SerializeField]
	private float speed = 16f;

	private bool areControllsEnabled = false;
	private float x, z;
	private GameManager gameManager;
	private TimerController timerController;
	private bool escaped = false;

	void Start() {
		gameManager = FindObjectOfType<GameManager>();
		timerController = FindObjectOfType<TimerController>();
	}
		
	public void EnableControlls(bool state) {
		areControllsEnabled = state;
	}

	public void SetFuelConsuptions(float ammount) {
		fuelConsumption = ammount;
	}

	public float GetFuelConsumption() {
		return fuelConsumption;
	}

	public float GetSpeed() {
		return speed;
	}

	public void SetSpeed(float spee) {
		speed = spee;
	}

    void Update()
    {

		if (areControllsEnabled) {
			x = Input.GetAxis("Horizontal");

			if(Input.GetKeyUp(KeyCode.Escape)) {
				gameManager.ShowMainMenuPrompt(true);
				escaped = true;
				gameManager.PauseTimer();
			}

			if (Input.GetKeyDown(KeyCode.Escape) && escaped) {
				gameManager.BackToMainMenu();
			} else if (!Input.GetKeyDown(KeyCode.Escape) && Input.anyKey && escaped) {
				gameManager.ShowMainMenuPrompt(false);
				escaped = false;
				if(timerController.GetTime() > 0) {
					gameManager.ResumeTimer();
				}
			}
    	}

	   //-----------------------------
       // Car has enought fuel to move
		if (FuelManager.GetFuel() > 0 && areControllsEnabled) {
			z = Input.GetAxis("Vertical");
			Translate(z);

			if (z != 0) {
				Rotate(x * z);
			}
	   //-----------------------------------------
       // Car run out of fuel while moving FORWARD
		} else if (FuelManager.GetFuel() <= 0 && z > 0) {
			z -= 0.4f * Time.deltaTime;
			Rotate(x * z);
			Translate(z);

			if (Input.GetAxis("Vertical") < 0f) {
				Translate(0);
				z = 0;
			}
		//------------------------------------------
		// Car run out of fuel while moving BACKWARD
		} else if (FuelManager.GetFuel() <= 0 && z < 0) {
			z += 0.4f * Time.deltaTime;
			Rotate(x * z);
			Translate(z);

			if (Input.GetAxis("Vertical") > 0f) {
				Translate(0);
				z = 0;
			}
      	 } 

	   if (Input.GetAxis("Vertical") != 0 && areControllsEnabled) {
       		FuelManager.ConsumeFuel(fuelConsumption);
       }
    }

    void Rotate(float x) {
		transform.Rotate(0,x * Time.deltaTime * 180f,0);
    }

    void Translate(float z) {
		transform.Translate(0,0,z * Time.deltaTime * speed);
    }

    public float GetX() {
    	return x;
    }

    public float GetZ() {
    	return z;
    }
}
