using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator anim;

    //[SerializeField]
    //private GameObject muzzleFlash;

	//public GameObject firePoint;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void ShootAnimation()
	{
		anim.SetTrigger("shoot");
	}

	public void Aim(bool canAim)
	{
		anim.SetBool("canAim", canAim);
	}

	/*private void TurnMuzzleFlash()
	{
		muzzleFlash.SetActive(true);
	}

	private void TurnOffMuzzleFlash()
	{
		muzzleFlash.SetActive(false);
	}*/

}
