using System;
using UnityEngine;

public class TriggerBarrier : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	public Action<bool> OnBallTriggerEnter;

	public Vector2 Size
	{
		get => spriteRenderer.size;
		set => spriteRenderer.size = value;
	}

	public Color Color { get; set; }
	public ObjectSide Side;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<Ball>(out Ball ball))
		{
			if (ball.Enabled && ball.Side == Side)
			{
				if (ball.CurrentColor == Color)
				{
					OnBallTriggerEnter?.Invoke(true);
				}
				else
				{
					OnBallTriggerEnter?.Invoke(false);
				}

				ball.Disable(true);
			}
		}
	}
}
