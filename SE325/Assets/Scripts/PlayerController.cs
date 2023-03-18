using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 moveDirection;
    public float speed = 5f;

    private float gravity = 20f;
    public float jumpForce = 10f;
    private float verticalVelocity;

    public float sprintSpeed = 10f;
    public float moveSpeed = 5f;
    public float crouchSpeed = 2f;

    private Transform cameraTransform;
    private float standHeight = 1.6f;
    private float crouchHeight = 1f;
    private bool isCrouching;



    private void Awake()
	{
		characterController = GetComponent<CharacterController>();
        cameraTransform = transform.GetChild(0);
	}
    
    void Update()
    {
        Movement();
        Sprint();
        Crouch();
    }


    private void Movement()
	{
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // bez ove linije player se ne krece gde gledamo
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        characterController.Move(moveDirection);
	}

    private void ApplyGravity()
	{
		if (characterController.isGrounded)
		{
            verticalVelocity -= gravity * Time.deltaTime;

            //jump
            if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
		else
		{
            verticalVelocity -= gravity * Time.deltaTime;
        }
        moveDirection.y = verticalVelocity * Time.deltaTime;
	}

    private void Sprint()
	{
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
		{
            speed = sprintSpeed;
		}

        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            speed = moveSpeed;
        }
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!isCrouching)
            {
                cameraTransform.localPosition = new Vector3(0f, crouchHeight, 0f);
                speed = crouchSpeed;
                isCrouching = true;
            }
            else
            {
                cameraTransform.localPosition = new Vector3(0f, standHeight, 0f);
                speed = moveSpeed;
                isCrouching = false;
            }
        }
    }
}
