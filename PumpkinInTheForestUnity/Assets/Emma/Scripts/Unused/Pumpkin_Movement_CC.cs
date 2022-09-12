using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin_Movement_CC : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6.0f;
    public float jumpHeight = 6.0f;
    public float gravityValue = -9.8f;

    private Vector2 moveInput;
    private Vector3 playerJump;
    private bool groundedPlayer;
    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
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
        groundedPlayer = controller.isGrounded;

        // Declare Variables
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        bool jump = Input.GetButtonDown("Jump");

        //Moving the character
        Vector3 direction = new Vector3(horizontal, controller.velocity.y, vertical).normalized;

        if (direction != Vector3.zero)
        {
            gameObject.transform.forward = direction;
        }

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

        // Jumping
        if (groundedPlayer && playerJump.y < 0)
        {
            playerJump.y = 0f;
        }

        if (jump && groundedPlayer)
        {
            playerJump.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerJump.y += gravityValue * Time.deltaTime;
        controller.Move(playerJump * Time.deltaTime);
    }

    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
