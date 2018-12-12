using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public float speedOrbit;
	public float speedRotate;
	public Transform target; 

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * speedRotate * Time.deltaTime,Space.Self);
		transform.RotateAround(target.position,Vector3.up,speedOrbit * Time.deltaTime);
	}
}
