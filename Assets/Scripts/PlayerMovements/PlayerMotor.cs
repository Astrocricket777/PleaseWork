using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    bool lerpCrouch;
    bool crouching;
    bool sprinting;
    float crouchTimer;

    PlayerHealth health;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        health = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!health.dead)
        {
            isGrounded = controller.isGrounded;

            if (lerpCrouch)
            {
                crouchTimer += Time.deltaTime;
                float p = crouchTimer / 1;
                p *= p;
                if (crouching)
                    controller.height = Mathf.Lerp(controller.height, 1, p);
                else
                    controller.height = Mathf.Lerp(controller.height, 2, p);

                if (p > 1)
                {
                    lerpCrouch = false;
                    crouchTimer = 0f;
                }
            }
        }
    }

    //recieve the inputs for our InputManger.cs and apply them to our character controller. 

    // Looks Like The Same Thing Here As PlayerLook.cs, You Need To Somehow Call It With A Vector2 As It's Argument.
    public void ProcessMove(Vector2 input)
    {
        if (!health.dead)
        {
            Vector3 moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            playerVelocity.y += gravity * Time.deltaTime;
            if (isGrounded && playerVelocity.y < 0)
                playerVelocity.y = -2f;
            controller.Move(playerVelocity * Time.deltaTime);

        }
        //Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (!health.dead)
        {
            if (isGrounded)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        }
    }

    public void Crouch()
    {
        if (!health.dead)
        {
            crouching = !crouching;
            crouchTimer = 0;
            lerpCrouch = true;

            if (crouching)
                speed = 3;
            else
                speed = 5;
        }
    }

    public void Sprint()
    {
        if (!health.dead)
        {
            sprinting = !sprinting;
            if (sprinting)
                speed = 8;
            else
                speed = 5;
        }
    }
}
