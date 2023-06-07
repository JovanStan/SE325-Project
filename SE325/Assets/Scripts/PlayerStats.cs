using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public int health = 100;
    private bool isDead = false;

    public Image healthStats, staminaStats, standingIcon, crouchIcon;
    public TextMeshProUGUI healthText;

    [Header("Cameras")]
    public GameObject normalCamera;
    public GameObject deathCamera;


	private void Awake()
	{
        healthText.text = health.ToString();
        instance = this;
	}


    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.F))
        {
            ApplyDamage(20);
        }*/
    }

    public void DisplayHealth(float health)
    {
        health /= 100f;
        healthStats.fillAmount = health;
    }

    public void DisplayStamina(float stamina)
    {
        stamina /= 100f;
        staminaStats.fillAmount = stamina;
    }

    public void ApplyDamage(int dmg)
    {
        if (isDead) return;

        health -= dmg;
        healthText.text = health.ToString();
        DisplayHealth(health);

        if (health <= 0)
        {
           
            health = 0;
            PlayerDied();
            isDead = true;
        }
    }

    private void PlayerDied()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponentInChildren<PlayerAttack>().enabled = false;
        GetComponentInChildren<MouseLook>().enabled = false;

        deathCamera.SetActive(true);
        deathCamera.transform.position = normalCamera.transform.position;
        deathCamera.transform.rotation = normalCamera.transform.rotation;
        normalCamera.SetActive(false);
        
    }
}
