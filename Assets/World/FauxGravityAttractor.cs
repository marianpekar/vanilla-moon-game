using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour {

    public float gravity = -12;

    public void Attract(Transform bodyTransform)
    {
        Vector3 gravityUp = (bodyTransform.position - transform.position).normalized;
        Vector3 localUp = bodyTransform.up;

        bodyTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * bodyTransform.rotation;
        bodyTransform.rotation = Quaternion.Slerp(bodyTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}