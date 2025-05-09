using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    public float rotationFactorPerFrame = 2f;
    private Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation = transform.rotation;

        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Horizontal input
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1f); //prevents faster diagonal movement

        if (move != Vector3.zero)
        {
            transform.forward = move;
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);

        

    }
}
