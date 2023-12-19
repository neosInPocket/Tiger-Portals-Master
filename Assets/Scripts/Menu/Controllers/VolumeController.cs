using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;

	private void Awake()
	{
		var controllers = GameObject.FindObjectsByType<VolumeController>(sortMode: FindObjectsSortMode.InstanceID);

		if (controllers.Length > 1)
		{
			gameObject.SetActive(false);
			return;
		}

		DontDestroyOnLoad(gameObject);
	}

	public void SetMusicVolume(int value)
	{
		audioSource.volume = (float)(value / 360f);
		SavingController.MusicVolume = audioSource.volume;
		SavingController.Save();
	}

	public void SetSFXVolume(int value)
	{
		SavingController.SFXVolume = (float)(value / 360f);
		SavingController.Save();
	}
}
