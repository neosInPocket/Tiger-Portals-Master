using UnityEngine;

public class VolumeSliderController : MonoBehaviour
{
	[SerializeField] private bool isMusicType;
	private VolumeController volumeController;

	private void Start()
	{
		volumeController = FindObjectOfType<VolumeController>();
	}

	public void SetVolume(int value)
	{
		if (isMusicType)
		{
			volumeController.SetMusicVolume(value);
		}
		else
		{
			volumeController.SetSFXVolume(value);
		}

	}
}
