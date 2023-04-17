using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light flashlight;
    private bool isActive = false;
    void Start()
    {
        flashlight = GetComponent<Light>();
    }

    
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.F))
		{
            isActive = !isActive;
		}

		if (isActive)
		{
            flashlight.intensity = 1.36f;
		}

		if (!isActive)
		{
            flashlight.intensity = 0f;
		}
    }
}
