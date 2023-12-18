using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rigidB;
	[SerializeField] private GameObject spawnEffect;
	[SerializeField] private SpriteRenderer spriteRenderer;
	private Vector2 currentSpeed;
	public Color CurrentColor
	{
		get => spriteRenderer.color;
		set => spriteRenderer.color = value;
	}

	public void Disable()
	{
		gameObject.SetActive(false);
		rigidB.constraints = RigidbodyConstraints2D.FreezeAll;
		rigidB.velocity = Vector2.zero;
	}

	public void Enable()
	{
		gameObject.SetActive(true);
		rigidB.constraints = RigidbodyConstraints2D.None;
		rigidB.velocity = Vector2.zero;
	}

	public void SetSpeed(float value)
	{
		rigidB.velocity = value * Vector2.up;
	}

	public void Freeze()
	{
		currentSpeed = rigidB.velocity;
		rigidB.constraints = RigidbodyConstraints2D.FreezeAll;
	}

	public void Unfreeze()
	{
		rigidB.constraints = RigidbodyConstraints2D.None;
		rigidB.velocity = currentSpeed;
	}
}
