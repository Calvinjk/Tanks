using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {

    public int          playerNum           = 0;
    public float        moveSpeed           = 1f;
    public float        turnSpeed           = 1f;
    public float        maxWeaponCooldown   = 1f;
    public float        bulletSpawnOffset   = 1f;
    public bool         invincible          = false;
    public GameObject   bulletPrefab;
    public bool         _________________________________;
    public float        accelerationInput   = 0f;
    public float        turningInput        = 0f;
    public float        weaponCooldown      = 0f;
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

        //Check Player and get inputs
        switch (playerNum) {
            case 1:
                //Turning input
                if (Input.GetKey(KeyCode.A))                                { turningInput = -1; }
                if (Input.GetKey(KeyCode.D))                                { turningInput = 1; }
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))   { turningInput = 0; } //Neither pressed
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))     { turningInput = 0; } //Both pressed

                //Acceleration input
                if (Input.GetKey(KeyCode.S))                                { accelerationInput = -1; }
                if (Input.GetKey(KeyCode.W))                                { accelerationInput = 1; }
                if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))   { accelerationInput = 0; } //Neither pressed
                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))     { accelerationInput = 0; } //Both pressed

                //Shoot shit!
                if (Input.GetKey(KeyCode.Space))                            { Shoot(); }
                break;
            case 2:
                //Turning input
                if (Input.GetKey(KeyCode.LeftArrow))                                        { turningInput = -1; }
                if (Input.GetKey(KeyCode.RightArrow))                                       { turningInput = 1; }
                if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))  { turningInput = 0; } //Neither pressed
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))    { turningInput = 0; } //Both pressed

                //Acceleration input
                if (Input.GetKey(KeyCode.DownArrow))                                        { accelerationInput = -1; }
                if (Input.GetKey(KeyCode.UpArrow))                                          { accelerationInput = 1; }
                if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))     { accelerationInput = 0; } //Neither pressed
                if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow))       { accelerationInput = 0; } //Both pressed

                //Shoot shit!
                if (Input.GetKey(KeyCode.KeypadEnter))                                      { Shoot(); }
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

    void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.tag == "Bullet" && !invincible) {
            Destroy(gameObject);
        }
    }

        void Shoot() {
        if (weaponCooldown == 0) {
            bullet = Instantiate(bulletPrefab, pos + transform.forward.normalized * bulletSpawnOffset, Quaternion.identity) as GameObject;

            BulletController bulletController = (BulletController)bullet.GetComponent(typeof(BulletController));

            bulletController.direction = transform.forward.normalized;

            //Reset weapon cooldown
            weaponCooldown = maxWeaponCooldown;
        }
    }
}
