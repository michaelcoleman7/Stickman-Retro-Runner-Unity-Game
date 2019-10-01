using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // == public fields ==
    // == private fields ==
    [SerializeField]
    private float moveSpeed = 15f;
    public float jumpForce;
    private Rigidbody2D rb;

    private bool onGround;
    public Transform PlatformCheck;
    public float checkRadius;
    public LayerMask platform;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // == private methods ==
    // Update is called once per frame
    void Update()
    {
        //Jump when space pressed or mouse clicked user should jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround || Input.GetMouseButtonDown((0)) && onGround)
        {
            rb.velocity = Vector2.up * jumpForce;
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
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}
