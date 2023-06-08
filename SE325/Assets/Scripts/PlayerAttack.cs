using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
	public float fireRate = 15f;
	private float fireTimer;
	public int damage = 20;

	private Animator anim;
	public Camera cam;
	//public GameObject GMObject;
	//private GM gm;

	public Animator zoomCameraAnim;
	private bool zoomed;
	public GameObject crosshair;

	public int maxAmmo = 30;
	private int currentAmmo;
	public int stashAmmo = 30;
	public float reloadTime = 1f;
	private bool isReloading = false;

	public TextMeshProUGUI currentAmmoText, stashAmmoText;

    private void Start()
    {
		//gm = GMObject.GetComponent<GM>();
    }


    private void Awake()
	{
		anim = GetComponent<Animator>();
		currentAmmo = maxAmmo;
		stashAmmoText.text = stashAmmo.ToString();
	}

	void Update()
	{
		if (isReloading) return;

		if (currentAmmo <= 0 && stashAmmo > 0)
		{
			StartCoroutine(Reload());
			return;
		}

		Shoot();
		ZoomInAndOut();
		Interact();
	}

	private void Shoot()
	{
		if (Input.GetMouseButton(0) && Time.time > fireTimer && currentAmmo > 0)
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
				if(hit.transform.gameObject.tag == "Hostile")
                {
					Enemy e = hit.transform.gameObject.GetComponent<Enemy>();
					e.TakeDamage(damage);
                }
			}

		}
	}

	private void Interact()
    {
        if (Input.GetKey(KeyCode.E))
        {
			RaycastHit hit;
			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
			{
				Debug.Log("Interacted with " + hit.transform.gameObject.name);

				// interact with quest giver
				if (hit.transform.gameObject.name == "NPC")
				{
                    if (!GM.instance.firstObjectiveCompleted)
                    {
						GM.instance.FirstObjectiveDone();
                    }
					else if(GM.instance.firstObjectiveCompleted && GM.instance.secondObjectiveCompleted)
                    {
						GM.instance.ThirdObjectiveDone();
                    }
				}

				// interact with second quest giver
				if(hit.transform.gameObject.name == "John")
                {
					if (GM.instance.thirdObjectiveCompleted)
						GM.instance.FourthObjectiveDone();
                }
			}
		}
    }

	private void ZoomInAndOut()
	{
		if (Input.GetMouseButtonDown(1))
		{
			zoomCameraAnim.Play("ZoomIn");
			crosshair.SetActive(false);
		}
		if (Input.GetMouseButtonUp(1))
		{
			zoomCameraAnim.Play("ZoomOut");
			crosshair.SetActive(true);
		}
	}

	IEnumerator Reload()
	{
		isReloading = true;
		anim.SetTrigger("reload");
		yield return new WaitForSeconds(2f);

		if (stashAmmo >= 30)
		{
			currentAmmo += 30;
			stashAmmo -= 30;
			currentAmmoText.text = currentAmmo.ToString();
			stashAmmoText.text = stashAmmo.ToString();
			if (stashAmmo <= 0)
			{
				stashAmmo = 0;
				anim.SetTrigger("idle");
				stashAmmoText.text = stashAmmo.ToString();
				Debug.Log("Nema Vise");
			}


			isReloading = false;
		}

	}
}

