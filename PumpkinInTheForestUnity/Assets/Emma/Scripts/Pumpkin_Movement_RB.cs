using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin_Movement_RB : MonoBehaviour
{
    public Rigidbody controller;

    public float speed = 20f;
    public float jumpHeight = 10f;
    public float gravityValue = -9.8f;

    private Vector2 moveInput;
    private Vector3 playerJump;
    private bool facingLeft = true;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Rigidbody>();
    }

    // Used with physics engine, can run several times per frame
    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (facingLeft == false && moveInput > 0)
        {
            Flip();
        }


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
            //Debug.Log("Grounded");
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            controller.velocity += new Vector3(0f, jumpHeight, 0f);
            //playerJump.y += Mathf.Sasqrt(jumpHeight * -2.0f * gravityValue);
        }
    }

    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
