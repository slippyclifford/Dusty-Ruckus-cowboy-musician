using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Player Movement Variables
    public float Movespeed;
    public float Jumpheight;
    private bool doubleJump;

    //Player grounded variables 
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    private bool grounded;


    //nonstick player
    private float moveVelocity;


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
       
        //this code makes the character double jump
        if(grounded)
            doubleJump = false;
        
        if(Input.GetKeyDown (KeyCode.Space)&& !doubleJump && !grounded){
            Jump();
            doubleJump = true;
        }
       
        //nonstick player
        moveVelocity = 0f;

        //this code allows the player to move from side to side using the "a" and "d" keys. 
        if(Input.GetKey (KeyCode.D)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(Movespeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = Movespeed;
        }
        if(Input.GetKey (KeyCode.A)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-Movespeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -Movespeed; 
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }



    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jumpheight);
    }
}