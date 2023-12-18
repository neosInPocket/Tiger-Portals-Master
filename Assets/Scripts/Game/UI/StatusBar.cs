using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
	[SerializeField] private Image statusFill;

	public void Start()
	{
		statusFill.fillAmount = 0;
	}

	public void Refresh(float fill)
	{
		statusFill.fillAmount = fill;
	}
}
