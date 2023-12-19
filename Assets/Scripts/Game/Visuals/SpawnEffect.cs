using System.Collections;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
	public Color CurrentColor { get; set; }

	public void Play(SpriteRenderer targetSpriteRenderer, CircleCollider2D targetCollider)
	{
		gameObject.SetActive(true);
		targetCollider.enabled = true;
		targetSpriteRenderer.enabled = true;
	}
}
