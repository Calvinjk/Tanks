﻿using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

    public int player1Score = 0;
    public int player2Score = 0;
    public bool ______________;

    public static Globals S;

    void Awake() {
        S = this;
        DontDestroyOnLoad(transform.gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
