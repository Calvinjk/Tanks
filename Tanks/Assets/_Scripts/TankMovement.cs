using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {

    public float horizontalInput = 0f;
    public float verticalInput = 0f;
    public float playerSpeed = 1f;

	// Use this for initialization
	void Start () {
        
	}

    void FixedUpdate() {
        horizontalInput = Input.GetAxis("Horizontal") * playerSpeed;
        verticalInput = Input.GetAxis("Vertical") * playerSpeed;

        Vector3 newVelocity = new Vector3(horizontalInput, 0, verticalInput);
        GetComponent<Rigidbody>().velocity = newVelocity;
    }
}
