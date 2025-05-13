using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isometric;

    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    public float rotationFactorPerFrame = 2f;
    private Quaternion currentRotation;

    private Animator animator;

    public bool isKissing;
    private bool kissTriggered;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKissing)
        {
            kissTriggered = false;

            currentRotation = transform.rotation;

            if (controller.isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            // Horizontal input
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (isometric)
            {
                move = Quaternion.Euler(0, 45, 0) * move;
            }
            move = Vector3.ClampMagnitude(move, 1f); //prevents faster diagonal movement

            if (move != Vector3.zero)
            {
                //walking
                animator.SetBool("isWalking", true);
                transform.forward = move;
                Quaternion targetRotation = Quaternion.LookRotation(move);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
            }
            else
            {
                //not walking
                animator.SetBool("isWalking", false);
            }

            // Apply gravity
            playerVelocity.y += gravityValue * Time.deltaTime;

            // Combine horizontal and vertical movement
            Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
            controller.Move(finalMove * Time.deltaTime);
        }
        else if (isKissing)
        {
            if (!kissTriggered)
            {
                animator.SetTrigger("Kiss");
                Score.Kiss();
                Sliders.t += 40f / (Score.kissCounter * 0.5f); 
                //play sound
                kissTriggered = true;
            }
        }
        

    }
}
