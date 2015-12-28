using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {

    public float        accelerationInput   = 0f;
    public float        turningInput        = 0f;
    public float        moveSpeed           = 1f;
    public float        turnSpeed           = 1f;
    public float        bulletSpeed         = 1f;
    public GameObject   bulletPrefab;
    public bool         ________________;
    public Vector3      pos;
    public Vector3      rotation;  
    public GameObject   bullet;

	// Use this for initialization
	void Start () {
        pos = transform.position;
	}

    void FixedUpdate() {
        //Update variables
        pos = transform.position;

        //Get input
        turningInput = Input.GetAxis("Horizontal") * turnSpeed;
        accelerationInput = Input.GetAxis("Vertical") * moveSpeed;

        //Rotation stuff
        rotation = transform.localRotation.eulerAngles;
        rotation.y += turningInput;
        transform.localRotation = Quaternion.Euler(rotation);

        //This is forwards and backwards movement
        Vector3 newVelocity = transform.forward.normalized * accelerationInput;
        GetComponent<Rigidbody>().velocity = newVelocity;

        //Shoot shit!
        if (Input.GetKeyDown(KeyCode.Space)) {
            bullet = Instantiate(bulletPrefab, pos + transform.forward.normalized, Quaternion.identity) as GameObject;

            bullet.GetComponent<Rigidbody>().velocity = transform.forward.normalized * bulletSpeed;
        }
    }
}
