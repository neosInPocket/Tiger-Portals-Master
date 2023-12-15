using TMPro;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class SliderVolume : Refreshable
{
	[SerializeField] private RadialSlider slider;
	[SerializeField] private TMP_Text valueText;
	[SerializeField] private VolumeType volumeType;

	public override void Refresh()
	{
		if (volumeType == VolumeType.Music)
		{
			slider.Value = SavingController.MusicVolume;
		}
		else
		{
			slider.Value = SavingController.SFXVolume;
		}

		valueText.text = ((int)(slider.Value * 100f)).ToString();
	}

	public void SetTextValue(int value)
	{
		valueText.text = ((int)(value / 360f * 100f)).ToString();
	}
}

public enum VolumeType
{
	Music,
	SFX
}
