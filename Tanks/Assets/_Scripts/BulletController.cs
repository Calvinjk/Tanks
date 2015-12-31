using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletController : MonoBehaviour {

    public float        bulletSpeed         = 1f;
    public Vector3      direction           = Vector3.zero;  //Make sure this vector always has a magnitude of 0 or 1
    public int          maxBounces          = 0;    //Set this to -1 to bounce forever.
    public float        maxTimeAlive        = 1f;   //Set this to -1 to live forever.
    public bool         _________________;
    public float        speedOffset         = 0.1f;
    public int          numBounces          = 0;
    public float        timeAlive           = 0;   
    public Rigidbody    rigidBody;

    void Start() {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        transform.position += direction * speedOffset * bulletSpeed;
        timeAlive += Time.fixedDeltaTime;
        if ((timeAlive >= maxTimeAlive) && (maxTimeAlive != -1)) {
            Destroy(gameObject);
        }
    }

	void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.tag == "Wall") {
            if (numBounces != maxBounces) {
                ++numBounces;

                //Bounce baby bounce!
                Bounce(transform.position, coll.contacts[0].point);
            } else {
                Destroy(this.gameObject);
            }
        }

        if (coll.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }

    void Bounce(Vector3 center, Vector3 contactPoint) {
        Vector3 offset = center - contactPoint; //This creates a vector between the two points.  An offset vector if you will

        //Separate our two offsets
        float verticalOffset = Mathf.Abs(offset.z);
        float horizontalOffset = Mathf.Abs(offset.x);

        Vector3 newVelocity = Vector3.zero;
        Vector3 oldVelocity = direction;

        //Figure out how to bounce!
        if (verticalOffset < horizontalOffset) {
            newVelocity = new Vector3(oldVelocity.x * -1, oldVelocity.y, oldVelocity.z);
        } else {    
            newVelocity = new Vector3(oldVelocity.x, oldVelocity.y, oldVelocity.z * -1);
        }

        direction = newVelocity.normalized;
    }
}
