using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
	private Light flashlight;
	private bool isActive = false;
	public GameObject flashlightImage;
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
			flashlight.intensity = 10f;
			flashlightImage.SetActive(true);
		}

		if (!isActive)
		{
			flashlight.intensity = 0f;
			flashlightImage.SetActive(false);
		}
	}
}
