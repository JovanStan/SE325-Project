using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	private void Update()
	{

	}

	public void LoadNewGame()
	{
		SceneManager.LoadScene("Cutscene1");
	}
}
