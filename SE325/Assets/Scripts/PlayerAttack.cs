using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
	public float fireRate = 15f;
	private float fireTimer;
	public float damage = 20f;

	private Animator anim;
	public Camera cam;

	public int maxAmmo = 30;
	private int currentAmmo;
	public int stashAmmo = 30;
	public float reloatTime = 1f;
	private bool isReloading = false;

	public TextMeshProUGUI currentAmmoText, stashAmmoText;
	public GameObject reloadingText;

	//[SerializeField]
	//private GameObject muzzleFlash;

	//public GameObject firePoint;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
		currentAmmo = maxAmmo;
		stashAmmoText.text = stashAmmo.ToString();
	}

	void Update()
	{
		if (isReloading) return;
		
		if(currentAmmo <= 0)
		{
			StartCoroutine(Reload());
			return;
		}
		Shoot();
	}

	private void Shoot()
	{
		if (Input.GetMouseButton(0) && Time.time > fireTimer)
		{
			anim.SetTrigger("shoot");
			fireTimer = Time.time + 1f / fireRate;

			currentAmmo--;
			currentAmmoText.text = currentAmmo.ToString();

			RaycastHit hit;
			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
			{
				Debug.Log(hit.transform.gameObject.name);

				// damage enemy
			}

		}
	}

	IEnumerator Reload()
	{
		isReloading = true;
		yield return new WaitForSeconds(1f);
		if (stashAmmo >= 30)
		{
			currentAmmo += 30;
			stashAmmo -= 30;
			currentAmmoText.text = currentAmmo.ToString();
			stashAmmoText.text = stashAmmo.ToString();
		}
		if (stashAmmo < 0)
		{
			stashAmmo = 0;
			currentAmmo = 0;
			stashAmmoText.text = stashAmmo.ToString();
			Debug.Log("Nema Vise");
		}
		isReloading = false;
	}


}
