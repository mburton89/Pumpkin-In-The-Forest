using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pumpkin_Movement_RB : MonoBehaviour
{
    public Rigidbody controller;

    public float speed = 20f;
    public float jumpHeight = 10f;
    public float gravityValue = -9.8f;

    private Vector2 moveInput;
    private Vector3 playerJump;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    public Animator anim;

    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Rigidbody>();
        //joint = GetComponent<FixedJoint>();
    }

    // Used with physics engine, can run several times per frame
    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {

        // Declare Variables
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();
        bool jump = Input.GetButtonDown("Jump");

        //Moving the character
        controller.velocity = new Vector3(moveInput.x * speed, controller.velocity.y, moveInput.y * speed);

        RaycastHit hit;

        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            controller.velocity += new Vector3(0f, jumpHeight, 0f);
            anim.SetBool("isJumping", true);
            //Debug.Log("jump");
        }
        else 
        {
            anim.SetBool("isJumping", false);
            //Debug.Log("no jump");
        }

        //Debug.Log(controller.velocity.y);

        //if (controller.velocity.y == 0)
        {
            //anim.SetBool("isJumping", false);
        }
        //else 
        {
            //anim.SetBool("isJumping", true);
        }

        if (controller.velocity.x == 0)
        {
            anim.SetBool("isWalking", false);
           // Debug.Log("not walk");
        }
        else
        {
            anim.SetBool("isWalking", true);
           // Debug.Log("walk");
        }

        //below code might be unnecessary, pineapple
        if (!sr.flipX && moveInput.x < 0)
        {
            sr.flipX = true;
        }
        else if (sr.flipX && moveInput.x > 0)
        {
            sr.flipX = false;
        }

    }

}
