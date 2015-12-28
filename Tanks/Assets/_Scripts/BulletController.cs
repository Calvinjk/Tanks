using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	void OnCollisionStay(Collision coll) {
        if (coll.gameObject.tag == "Wall") {
            Destroy(this.gameObject);
        }
    }
}
