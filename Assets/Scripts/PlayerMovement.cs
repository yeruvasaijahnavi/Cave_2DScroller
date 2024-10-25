using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float speed;
    public float inputDirection;
    public SpriteRenderer spriteRenderer;

    // jump vars
    public float jumpForce;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform playerFeetTransform;
    public float groundCheckCircle;

    // prevent flying
    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    public bool isJumping;


    // running animation
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        // flipping left and right
        inputDirection = Input.GetAxisRaw("Horizontal");
        if (inputDirection < 0)
        {
            spriteRenderer.flipX = true;
        } else if (inputDirection > 0)
        {
            spriteRenderer.flipX = false;
        }

        // -- Jump --

        // prevent inf jumps
        // OlC: where, size of circle, check for what?
        isGrounded = Physics2D.OverlapCircle(playerFeetTransform.position, groundCheckCircle, groundLayer);

        if (isGrounded == true && Input.GetButtonDown("Jump")) // on ground + key press
        {
            isJumping = true;
            jumpTimeCounter = jumpTime; // reset time
            playerRB.velocity = Vector2.up * jumpForce; // jump
        }

        // keep going up as long as key is pressed
        if (Input.GetButton("Jump") && isJumping == true) // key is pressed & isJumping then fly
        {
            if (jumpTimeCounter > 0) { // until timer runs out
                playerRB.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false; // to prevent double jumps
            }
        }

        // -- set animator params --
        anim.SetBool("run", inputDirection != 0);
        
    }

    void FixedUpdate()
    {
        playerRB.velocity = new Vector2 (inputDirection * speed, playerRB.velocity.y);
    }
}
