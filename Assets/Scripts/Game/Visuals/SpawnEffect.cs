using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
	[SerializeField] private ParticleSystem[] particleSystems;
	public Color CurrentColor { get; set; }

	private void OnEnable()
	{
		foreach (var system in particleSystems)
		{
			var main = system.main;
			main.startColor = CurrentColor;
		}

		StartCoroutine(Effect());
	}

	private IEnumerator Effect()
	{
		yield return new WaitForSeconds(1);
		gameObject.SetActive(false);
	}
}
