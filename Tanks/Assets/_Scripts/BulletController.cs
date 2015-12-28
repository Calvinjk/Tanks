using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Wall") {
            Destroy(this.gameObject);
        }
    }
}
