using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour
{
	public AudioMixer audioMixer, buttonMixer;
	Resolution[] resolutions;
	public TMP_Dropdown resolutionDropdown;

	public AudioSource sfx;

	private void Start()
	{
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		int currentIndex = 0;
		List<string> options = new List<string>();

		for(int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
			{
				currentIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentIndex;
		resolutionDropdown.RefreshShownValue();
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void SetVolume(float value)
	{
		audioMixer.SetFloat("volume", value);
	}

	public void SetButtonVolume(float volume)
	{
		buttonMixer.SetFloat("buttonVolume", volume);
	}

	public void SetQuality(int index)
	{
		QualitySettings.SetQualityLevel(index);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}

	public void PlaySfx()
	{
		sfx.Play();
	}

	public void LoadNewGame()
	{
		SceneManager.LoadScene("Cutscene1");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
