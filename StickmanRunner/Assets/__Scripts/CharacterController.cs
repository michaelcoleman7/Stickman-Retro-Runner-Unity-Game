﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStartValue;
    public float speedMultiplyer;
    public float scoreSpeedIncrease;
    private float scoreSpeedIncreaseStartValue;
    private float scoreSpeedIncreaseCount;
    private float scoreSpeedIncreaseCountStartValue;
    public float jumpForce;
    public float jumpPeriod;
    private float jumpPeriodTimer;
    private bool jumping;
    private bool doubleJump;
    private Rigidbody2D rb;

    private bool onGround;
    public Transform PlatformCheck;
    public float checkRadius;
    public LayerMask platform;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    public GameController gameController;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //set the Jump period timer to the jump period specified
        jumpPeriodTimer = jumpPeriod;

        // save values for resetting the game
        moveSpeedStartValue = moveSpeed;
        scoreSpeedIncreaseCountStartValue = scoreSpeedIncreaseCount;
        scoreSpeedIncreaseStartValue = scoreSpeedIncrease;
        //initialize the player jumping as false for double jump
        jumping = false;
    }

    void Update()
    {
        //Jump when space pressed or mouse clicked user should jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround || Input.GetMouseButtonDown((0)))
        {
            //if player is on the ground
            if (onGround)
            {
                //jump player by the jump force specified
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                // player has initiated a jump
                jumping = true;
            }
            //if in the air and double jump is true
            if (!onGround && doubleJump) 
            {
                //jump the player
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                //set the timer to the jump period
                jumpPeriodTimer = jumpPeriod;

                // player has initiated a jump
                jumping = true;

                //set double jump to false
                doubleJump = false;
            }
        }
        //Jump when space pressed or mouse clicked user should jump and the player is already jumping
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton((0))) && jumping)
        {
            //if jump timer is > 0
            if (jumpPeriodTimer > 0)
            {
                //jump player by the jump force specified
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                //as player jumps timer will go down
                jumpPeriodTimer -= Time.deltaTime;

                //If the player pref value for MutedSFX is set to false
                if (PlayerPrefs.GetString("MutedSFX") == "false")
                {
                    //Play Jump sound clip with delay to avoid multiple sound effects playing during powered up jump
                    jumpSound.PlayDelayed(0.05f);
                }
            }
        }

        //if user lifts space key or the mouse click
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) 
        {
            //set timer to 0
            jumpPeriodTimer = 0;

            //set jumping to false
            jumping = false;
        }

        //if user hit ground, reset jump abilities
        if (onGround) 
        {
            //set timer to the jump period
            jumpPeriodTimer = jumpPeriod;

            //set doublejump ability to true
            doubleJump = true;
        }
    }

    void FixedUpdate()
    {
        // Have detection for when the user is on the ground using a game object placed at players feet.
        onGround = Physics2D.OverlapCircle(PlatformCheck.position, checkRadius, platform);

        if (transform.position.x > scoreSpeedIncrease) 
        {
            scoreSpeedIncreaseCount = scoreSpeedIncrease;

            //increase the distance the increase occurs at as the player will be moving faster
            scoreSpeedIncrease *= speedMultiplyer;

            //increase move speed by the multiplyer
            moveSpeed *= speedMultiplyer;

        }

        //Call player movement function
        Move();
    }


    private void Move()
    {
        //Move player constantly by the move speed on the y axis
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }


    //When user collides with a object tagged with deatharea- Adopted from https://gamedev.stackexchange.com/questions/82119/simple-collision-detection-in-unity-2d
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "DeathArea") 
        {
            //call restart game function
            gameController.RestartGame();
            //reset movement speed
            moveSpeed = moveSpeedStartValue;
            //reset score increase count
            scoreSpeedIncreaseCount = scoreSpeedIncreaseCountStartValue;
            //reset score increase
            scoreSpeedIncrease = scoreSpeedIncreaseStartValue;
            //if sound effects are on, then play the death sound
            if (PlayerPrefs.GetString("MutedSFX") == "false")
            {
                //Play Jump sound clip - adapted from https://docs.unity3d.com/ScriptReference/AudioSource.Play.html
                deathSound.Play();
            }
        }
    }
}
