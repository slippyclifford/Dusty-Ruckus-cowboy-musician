﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;

    public Rigidbody2D Pc;

    public GameObject EnemyDeath;
    public GameObject ProjectileParticle;

    public int PointsForKill;

    // Use this for initialization
    void Start()
    {
        // Pc = FindObjectOfType<Rigidbody2D>();
        if (Pc.transform.localScale.x < 0)
            Speed = -Speed;
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Score_Manager.AddPoints(PointsForKill);
        }
        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);

    }


}
