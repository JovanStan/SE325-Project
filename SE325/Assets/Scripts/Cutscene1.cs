using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene1 : MonoBehaviour
{
	public GameObject playButton;

	private void Start()
	{
		StartCoroutine(ShowButton());
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("TestJovan");
	}

	IEnumerator ShowButton()
	{
		yield return new WaitForSeconds(12.7f);
		playButton.SetActive(true);
	}
}
