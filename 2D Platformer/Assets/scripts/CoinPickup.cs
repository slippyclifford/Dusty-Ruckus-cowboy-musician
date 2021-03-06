﻿using System.Collections;
using UnityEngine;

public class CoinPickup : MonoBehaviour {
    public int pointsToAdd;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == null)
            return;
        
        Score_Manager.AddPoints (pointsToAdd);

        Destroy (gameObject);
    }
}