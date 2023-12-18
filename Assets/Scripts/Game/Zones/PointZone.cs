using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointZone : MonoBehaviour
{
	[SerializeField] private ParticleSystem mainGlow;
	[SerializeField] private ParticleSystem dust;

	public float Width
	{
		get => m_width;
		set
		{
			m_width = value;
			var scale = mainGlow.transform.localScale;
			scale.z = value;
			mainGlow.transform.localScale = scale;
		}
	}

	public float Height
	{
		get => m_height;
		set
		{
			m_height = value;
			var scale = mainGlow.transform.localScale;
			scale.x = value;
			mainGlow.transform.localScale = scale;
		}
	}

	public Vector2 Size
	{
		get => mainGlow.transform.localScale;
		set
		{
			Height = value.y;
			Width = value.x;
		}
	}

	public Color Color
	{
		get => m_color;
		set
		{
			m_color = value;
			var mainGlowMain = mainGlow.main;
			var mainGlowAlpha = mainGlowMain.startColor.color.a;
			value.a = mainGlowAlpha;
			mainGlowMain.startColor = value;

			var dustMain = dust.main;
			var dustMainAlpha = mainGlowMain.startColor.color.a;
			value.a = dustMainAlpha;
			dustMain.startColor = value;
		}
	}

	private float m_width;
	private float m_height;
	private Color m_color;
}
