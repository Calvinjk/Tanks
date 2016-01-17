using UnityEngine;
using System.Collections;

public class TEMPORARY_MOVE_TO_SCENE : MonoBehaviour {

    string text = "MainScene";

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Application.LoadLevel(text);
    }
}
