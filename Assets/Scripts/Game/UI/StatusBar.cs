using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
	[SerializeField] private Image statusFill;
	[SerializeField] private float fillSpeed;

	public void Start()
	{
		statusFill.fillAmount = 0;
	}

	public void Refresh(float fill)
	{
		StopAllCoroutines();
		StartCoroutine(FillRoutine(fill));
	}

	private IEnumerator FillRoutine(float fill)
	{
		var destination = fill - statusFill.fillAmount;
		var magnitude = Mathf.Abs(destination);
		int direction = (int)(destination / magnitude);
		float currentFill = statusFill.fillAmount;

		while (direction > 0 && statusFill.fillAmount < fill || direction < 0 && statusFill.fillAmount > fill)
		{
			currentFill += direction * fillSpeed * Time.deltaTime * (magnitude + 0.01f);
			magnitude = Mathf.Abs(fill - currentFill);
			statusFill.fillAmount = currentFill;
			yield return new WaitForEndOfFrame();
		}
	}
}
