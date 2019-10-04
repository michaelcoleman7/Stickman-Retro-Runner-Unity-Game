using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 15f;
    public float jumpForce;
    public float jumpPeriod;
    private float jumpPeriodTimer;
    private Rigidbody2D rb;

    private bool onGround;
    public Transform PlatformCheck;
    public float checkRadius;
    public LayerMask platform;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //set the Jump period timer to the jump period specified
        jumpPeriodTimer = jumpPeriod;
    }

    void Update()
    {
        //Jump when space pressed or mouse clicked user should jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround || Input.GetMouseButtonDown((0)) && onGround)
        {
            //jump player by the jump force specified
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton((0)))
        {
            if (jumpPeriodTimer > 0)
            {
                //jump player by the jump force specified
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                //as player jumps timer will go down
                jumpPeriodTimer -= Time.deltaTime;
            }
        }

        //if user lifts space key or the mouse click
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) 
        {
            //set timer to 0
            jumpPeriodTimer = 0;
        }

        //if user hit ground, reset jump period timer
        if (onGround) 
        {
            jumpPeriodTimer = jumpPeriod;
        }


        //Can add double jump code - need to discuss with client
        /*//Jump when space pressed and user still has a double jump left
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump > 0) 
        {
            rb.velocity = Vector2.up * jumpForce;
            doubleJump--;
        }
        //Jump when space pressed and user but has no double jump left
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump == 0 && onGround)
        {
            rb.velocity = Vector2.up * jumpForce;
        }*/

    }

    void FixedUpdate()
    {
        // Have detection for when the user is on the ground using a game object placed at players feet.
        onGround = Physics2D.OverlapCircle(PlatformCheck.position, checkRadius, platform);

        //Call player movement function
        Move();
    }


    private void Move()
    {
        //Move player constantly by the move speed on the y axis
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}
