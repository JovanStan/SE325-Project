using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    public int zoom = 30;
    public int normal = 45;
    public float smooth = 5f;

    private bool isZoomed = false;
    private bool notZoomed = true;

    private Camera cam;

	private void Awake()
	{
		cam = GetComponentInChildren<Camera>();
	}


	void Update()
    {
		if (Input.GetMouseButtonDown(1))
		{
            isZoomed = !isZoomed;
		}

		if (isZoomed)
		{
			cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom, smooth * Time.deltaTime);
		}

		if (Input.GetMouseButtonUp(1))
		{			isZoomed = !notZoomed;
		}

		if (notZoomed)
		{
			cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normal, smooth * Time.deltaTime);
		}
    }
}
