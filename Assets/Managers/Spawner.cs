using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject cone;
	public GameObject coneBox;
	public GameObject fuel;
	public GameObject cursedCone;
	public GameObject additives;
	public GameObject speedBooster;

	public void SpawnCone () {
		Instantiate(cone,Random.onUnitSphere,Quaternion.identity);
	}

	public void SpawnConeBox () {
		Instantiate(coneBox,Random.onUnitSphere,Quaternion.identity);
	}

	public void SpawnCursedCone () {
		Instantiate(cursedCone,Random.onUnitSphere,Quaternion.identity);
	}

	public void SpawnFuel() {
		Instantiate(fuel,Random.onUnitSphere,Quaternion.identity);
	}

	public void SpawnAdditives () {
		Instantiate(additives,Random.onUnitSphere,Quaternion.identity);
	}

	public void SpawnSpeedBooster () {
		Instantiate(speedBooster,Random.onUnitSphere,Quaternion.identity);
	}
}
