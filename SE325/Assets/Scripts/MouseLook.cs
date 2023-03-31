using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
	[SerializeField]
    private Transform playerRoot, cameraParent;
    public Slider sensSlider;

    public static MouseLook instance;

    public float sensitivity = 3f;

    private Vector2 lookLimits = new Vector2(-70f, 80f);
    private Vector2 lookAngles;
    private Vector2 currentMouseLook;


	private void Awake()
	{
        instance = this;
	}

	void Start()
    {
        sensitivity = PlayerPrefs.GetFloat("currentSensitivity", 3);
        //sensSlider.value = sensitivity / 10;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LookAround();
        PlayerPrefs.SetFloat("currentSensitivity", sensitivity);
    }

    private void LookAround()
	{
        currentMouseLook = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        lookAngles.x += currentMouseLook.x * sensitivity;
        lookAngles.y += currentMouseLook.y * sensitivity;

        // clamp value
        lookAngles.x = Mathf.Clamp(lookAngles.x, lookLimits.x, lookLimits.y);

        cameraParent.localRotation = Quaternion.Euler(lookAngles.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
	}

    public void AdjustSpeed(float newSpeed)
	{
        sensitivity = newSpeed;
	}
}
