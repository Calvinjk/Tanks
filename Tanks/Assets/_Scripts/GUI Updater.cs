using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIUpdater : MonoBehaviour {

    public bool ___________________;
    Globals globals;
    Text player1Text;
    Text player2Text;


	// Use this for initialization
	void Start () {
        globals = (Globals)GameObject.Find("Global Variables").GetComponent(typeof(Globals));
        player1Text = GameObject.Find("Player1Score").GetComponent<Text>();
        player2Text = GameObject.Find("Player2Score").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        player1Text.text = "Player1: " + globals.player1Score.ToString();
        player2Text.text = "Player2: " + globals.player2Score.ToString();
    }
}
