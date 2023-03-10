using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Text playerName;
	public Button confirmButton;

	private void Update()
	{
		if(playerName.text.Length <= 3)
		{
			confirmButton.interactable = false;
		}
		else
		{
			confirmButton.interactable = true;
		}
	}

	public void LoadNewGame()
	{
		SceneManager.LoadScene("Cutscene1");
	}
}
