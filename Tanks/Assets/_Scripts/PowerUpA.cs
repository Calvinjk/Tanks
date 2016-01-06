using UnityEngine;
using System.Collections;

public class PowerUpA : MonoBehaviour {

	void OnCollisionEnter (Collision col){
        if(col.gameObject.tag == "Tank"){
            Destroy(this.gameObject);
        }
    }

}
    