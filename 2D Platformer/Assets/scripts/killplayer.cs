﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killplayer : MonoBehaviour {

    public LevelManager LevelManager;


	// Use this for initialization
	void Start () {
        LevelManager = FindObjectOfType <LevelManager>();
	}

	 void OnTriggerEnter2D(Collider2D other)
	{
        if(other.name == "Pc"){
            LevelManager.RespawnPc();
        }
	}

}
