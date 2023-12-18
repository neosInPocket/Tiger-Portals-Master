using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPortalRenderer : MonoBehaviour
{
	[SerializeField] private ParticleSystem mainGlow;
	[SerializeField] private ParticleSystem centerDark;
	[SerializeField] private ParticleSystem edgeGlow;
	[SerializeField] private ParticleSystem particles;
	[SerializeField] private float rainbowSpeed;
	private ParticleSystem.MainModule glowMain;
	private ParticleSystem.MainModule centerMain;
	private ParticleSystem.MainModule edgeMain;
	private ParticleSystem.MainModule particlesMain;

	private void Start()
	{
		glowMain = mainGlow.main;
		centerMain = centerDark.main;
		edgeMain = edgeGlow.main;
		particlesMain = particles.main;
	}

	private void Update()
	{
		IncreaseMainModuleColor(glowMain);
		IncreaseMainModuleColor(centerMain);
		IncreaseMainModuleColor(edgeMain);
		IncreaseMainModuleColor(particlesMain);
	}

	private void IncreaseMainModuleColor(ParticleSystem.MainModule module)
	{
		var a = module.startColor.color.a;

		float h = 0;
		float s = 0;
		float v = 0;
		Color.RGBToHSV(module.startColor.color, out h, out s, out v);

		h += rainbowSpeed;

		var newColor = Color.HSVToRGB(h, s, v);
		newColor.a = a;

		module.startColor = newColor;
	}
}
