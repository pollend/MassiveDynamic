﻿using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public MapManager mM;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.F))
        {
            mM.toggleLayableFoundation(true);
        }
	}
}
