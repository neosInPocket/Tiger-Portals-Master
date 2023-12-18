using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
	[SerializeField] private ParticleSystem[] particleSystems;
	public Color CurrentColor { get; set; }

	public void Disable(GameObject go)
	{
		gameObject.SetActive(true);

		foreach (var system in particleSystems)
		{
			var main = system.main;
			main.startColor = CurrentColor;
		}

		StartCoroutine(DeathRoutine(go));
	}

	private IEnumerator DeathRoutine(GameObject go)
	{
		yield return new WaitForSeconds(1);
		go.SetActive(false);
	}
}
