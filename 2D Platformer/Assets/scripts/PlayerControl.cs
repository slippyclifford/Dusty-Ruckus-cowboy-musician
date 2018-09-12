using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Player Movement Variables
    public int Movespeed;
    public float Jumpheight;

    //Player grounded variables 
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    private bool grounded;


    // Use this for initialization
    void Start()
    {

    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
    }

    // Update is called once per frame
    void Update()
    {

        //This code makes the character jump
        if (Input.GetKeyDown(KeyCode.Space) & grounded)
        {
            Jump();
        }
        //this code allows the player to move from side to side using the "a" and "d" keys. 
        if(Input.GetKey (KeyCode.D)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(Movespeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if(Input.GetKey (KeyCode.A)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-Movespeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jumpheight);
    }
}