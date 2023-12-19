using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrailRenderer : MonoBehaviour
{
	[SerializeField] private ParticleSystem[] particleSystems;

	public void SetColor(Color color)
	{
		foreach (var system in particleSystems)
		{
			var main = system.main;
			var alpha = main.startColor.color.a;
			color.a = alpha;
			main.startColor = color;
		}
	}
}
