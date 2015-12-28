using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {

    public float accelerationInput = 0f;
    public float turningInput = 0f;
    public float moveSpeed = 1f;
    public float turnSpeed = 1f;
    public Vector3 rotation;

	// Use this for initialization
	void Start () {
        
	}

    void FixedUpdate() {
        turningInput = Input.GetAxis("Horizontal") * turnSpeed;
        accelerationInput = Input.GetAxis("Vertical") * moveSpeed;

        //Rotation stuff
        rotation = transform.localRotation.eulerAngles;
        rotation.y += turningInput;
        transform.localRotation = Quaternion.Euler(rotation);

        //This is forwards and backwards movement
        Vector3 newVelocity = transform.forward.normalized * accelerationInput;
        GetComponent<Rigidbody>().velocity = newVelocity;

    }
}
