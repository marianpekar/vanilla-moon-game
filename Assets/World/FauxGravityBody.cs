using UnityEngine;

public class FauxGravityBody : MonoBehaviour {

    public FauxGravityAttractor attractorPlanet;
    private Transform bodyTransform;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

		bodyTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractorPlanet)
        {
			attractorPlanet.Attract(bodyTransform);
        }
    }
}