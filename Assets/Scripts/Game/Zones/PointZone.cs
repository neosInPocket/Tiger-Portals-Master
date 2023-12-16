using System.Collections;
using System.Collections.Generic;
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
			scale.x = value;
			mainGlow.transform.localScale = scale;

			var dustScale = dust.shape.scale;
			dustScale.x = value;
			var dustShape = dust.shape;
			dustShape.scale = dustScale;
		}
	}

	public float Height
	{
		get => m_height;
		set
		{
			m_height = value;
			var scale = mainGlow.transform.localScale;
			scale.z = value;
			mainGlow.transform.localScale = scale;

			var dustScale = dust.shape.scale;
			dustScale.z = value;
			var dustShape = dust.shape;
			dustShape.scale = dustScale;
		}
	}

	private float m_width;
	private float m_height;
}
