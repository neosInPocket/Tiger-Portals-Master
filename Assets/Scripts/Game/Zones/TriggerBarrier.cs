using UnityEngine;

public class TriggerBarrier : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;

	public Vector2 Size
	{
		get => spriteRenderer.size;
		set => spriteRenderer.size = value;
	}
}
