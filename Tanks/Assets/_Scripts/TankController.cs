using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {

    public int          playerNum           = 0;
    public float        moveSpeed           = 1f;
    public float        turnSpeed           = 1f;
    public float        maxWeaponCooldown      = 1f;
    public GameObject   bulletPrefab;
    public bool         _________________________________;
    public float        accelerationInput   = 0f;
    public float        turningInput        = 0f;
    public float        weaponCooldown = 0f;
    public Vector3      pos;
    public Vector3      rotation;  
    public GameObject   bullet;

	// Use this for initialization
	void Start () {
        pos = transform.position;
	}

    void FixedUpdate() {
        //Update and reset variables
        pos = transform.position;
        if (weaponCooldown > 0) {
            weaponCooldown -= Time.deltaTime;
            if (weaponCooldown < 0) { weaponCooldown = 0; }
        }

        //I am upset that I have to do this, but this is the fix for now.
        if (turningInput < -1)      { turningInput = -1; }
        if (turningInput > 1)       { turningInput = 1; }
        if (accelerationInput < -1) { accelerationInput = -1; }
        if (accelerationInput > 1)  { accelerationInput = 1; }

        //Check Player and get inputs
        switch (playerNum) {
            case 1:
                //Turning input
                if (Input.GetKeyDown(KeyCode.A))    { turningInput -= 1; }
                if (Input.GetKeyDown(KeyCode.D))    { turningInput += 1; }
                if (Input.GetKeyUp(KeyCode.A))      { turningInput += 1; }
                if (Input.GetKeyUp(KeyCode.D))      { turningInput -= 1; }

                //Acceleration input
                if (Input.GetKeyDown(KeyCode.S))    { accelerationInput -= 1; }
                if (Input.GetKeyDown(KeyCode.W))    { accelerationInput += 1; }
                if (Input.GetKeyUp(KeyCode.S))      { accelerationInput += 1; }
                if (Input.GetKeyUp(KeyCode.W))      { accelerationInput -= 1; }

                //Shoot shit!
                if (Input.GetKey(KeyCode.Space))    { Shoot(); }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.LeftArrow))    { turningInput -= 1; }
                if (Input.GetKeyDown(KeyCode.RightArrow))   { turningInput += 1; }
                if (Input.GetKeyUp(KeyCode.LeftArrow))      { turningInput += 1; }
                if (Input.GetKeyUp(KeyCode.RightArrow))     { turningInput -= 1; }

                //Acceleration input
                if (Input.GetKeyDown(KeyCode.DownArrow))    { accelerationInput -= 1; }
                if (Input.GetKeyDown(KeyCode.UpArrow))      { accelerationInput += 1; }
                if (Input.GetKeyUp(KeyCode.DownArrow))      { accelerationInput += 1; }
                if (Input.GetKeyUp(KeyCode.UpArrow))        { accelerationInput -= 1; }

                //Shoot shit!
                if (Input.GetKey(KeyCode.KeypadEnter))  { Shoot(); }
                break;
            default:
                print("INVALID PLAYERNUM");
                break;
        }

        //Scale the inputs
        turningInput *= turnSpeed;
        accelerationInput *= moveSpeed;

        //Rotation stuff
        rotation = transform.localRotation.eulerAngles;
        rotation.y += turningInput;
        transform.localRotation = Quaternion.Euler(rotation);

        //Forwards and backwards movement
        Vector3 newVelocity = transform.forward.normalized * accelerationInput;
        GetComponent<Rigidbody>().velocity = newVelocity;
    }

    void Shoot() {
        if (weaponCooldown == 0) {
            bullet = Instantiate(bulletPrefab, pos + transform.forward.normalized, Quaternion.identity) as GameObject;

            BulletController bulletController = (BulletController)bullet.GetComponent(typeof(BulletController));

            bulletController.direction = transform.forward.normalized;

            //Reset weapon cooldown
            weaponCooldown = maxWeaponCooldown;
        }
    }
}
