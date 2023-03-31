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
    private bool isCrouching = false;

    private float sprintStamina = 100f;
    private float sprintStaminaSpent = 10f;

    public static PlayerController instance;



    private void Awake()
	{
		characterController = GetComponent<CharacterController>();
        cameraTransform = transform.GetChild(0);
        instance = this;
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
        if (sprintStamina > 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
            {
                speed = sprintSpeed;
            }
        }

		if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
		{
			speed = moveSpeed;
		}


        // trosi staminu dok drzimo shift
        if(Input.GetKey(KeyCode.LeftShift) && !isCrouching)
		{
            sprintStamina -= sprintStaminaSpent * Time.deltaTime;
            PlayerStats.instance.DisplayStamina(sprintStamina);
            if (sprintStamina <= 0)
			{
                sprintStamina = 0f;
                speed = moveSpeed;
			}
		}
		else
		{
            if(sprintStamina != 100f)
			{
                sprintStamina += (sprintStaminaSpent / 2) * Time.deltaTime;
                PlayerStats.instance.DisplayStamina(sprintStamina);

                if(sprintStamina > 100f)
				{
                    sprintStamina = 100f;
				}
			}
		}
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (!isCrouching)
            {
                cameraTransform.localPosition = new Vector3(0f, crouchHeight, 0f);
                speed = crouchSpeed;
                isCrouching = true;
            } 
        }

		if (Input.GetKeyUp(KeyCode.C))
		{
			if (isCrouching)
			{
                cameraTransform.localPosition = new Vector3(0f, standHeight, 0f);
                speed = moveSpeed;
                isCrouching = false;
            }
		}

    }
}
