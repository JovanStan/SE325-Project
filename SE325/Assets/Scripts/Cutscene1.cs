using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene1 : MonoBehaviour
{
	public GameObject playButton;

	private void Start()
	{
		StartCoroutine(ShowButton());
	}

	IEnumerator ShowButton()
	{
		yield return new WaitForSeconds(12.7f);
		playButton.SetActive(true);
	}
}
