using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isActive = false;

    void Start()
    {
        
    }

    
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            isActive = !isActive;
            PausePanel.SetActive(isActive);
		}
		if (PausePanel.gameObject.activeInHierarchy)
		{
            Time.timeScale = 0.0f;
            MouseLook.instance.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
		}
		else 
        { 
            Time.timeScale = 1.0f;
            MouseLook.instance.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
