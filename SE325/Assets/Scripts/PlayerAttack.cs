using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public float fireRate = 15f;
	private float fireTimer;
	public float damage = 20f;

	private Animator anim;
	public Camera cam;

	//[SerializeField]
	//private GameObject muzzleFlash;

	//public GameObject firePoint;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		Shoot();
	}

	private void Shoot()
	{
		if (Input.GetMouseButton(0) && Time.time > fireTimer)
		{
			anim.SetTrigger("shoot");
			fireTimer = Time.time + 1f / fireRate;

			RaycastHit hit;
			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
			{
				Debug.Log("WE hit " + hit.transform.gameObject.name);
			}

		}
	}

}
