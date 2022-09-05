using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin_Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float jumpForce = 2f;

    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {

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
        //see Input Manager under Project Settings for string options

        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        bool jump = Input.GetButtonDown("Jump");

        //declare new vector3 struct with x, z, y axis input

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //magnitude is the distance between 2 vectors (length)...normalized takes magnitude out (if two inputs)
        
        if (direction.magnitude >= 0.1f)
        {
            //deltaTime is the interval in sec from last frame

            controller.Move(direction * speed * Time.deltaTime);
        }

        if (jump)
        {
            //controller.velocity = Vector2.up * jumpForce;
        }

        controller.detectCollisions = true;
    }

    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
