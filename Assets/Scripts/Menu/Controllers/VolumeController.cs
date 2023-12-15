using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;

	private void Start()
	{
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
