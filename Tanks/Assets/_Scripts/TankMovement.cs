using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {

    public float horizontalInput = 0f;
    public float verticalInput = 0f;
    public float playerSpeed = 1f;
    public Vector3 playerPos;

	// Use this for initialization
	void Start () {
        playerPos = transform.position;
	}

    void FixedUpdate() {
        horizontalInput = Input.GetAxis("Horizontal") * playerSpeed;
        verticalInput = Input.GetAxis("Vertical") * playerSpeed;

        playerPos = new Vector3(playerPos.x + horizontalInput, playerPos.y, playerPos.z + verticalInput);
        transform.position = playerPos;
    }
}
