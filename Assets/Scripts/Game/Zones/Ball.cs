using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rigidB;
	[SerializeField] private SpawnEffect spawnEffect;
	[SerializeField] private DeathEffect deathEffect;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private Transform trailsContainer;

	private Vector2 currentSpeed;
	public Color CurrentColor
	{
		get => spriteRenderer.color;
		set => spriteRenderer.color = value;
	}

	public bool Enabled { get; set; }
	public ObjectSide Side { get; set; }

	public Action<Ball> OnDisable;

	public void Disable(bool withEffect)
	{
		Enabled = false;
		rigidB.constraints = RigidbodyConstraints2D.FreezeAll;
		rigidB.velocity = Vector2.zero;

		if (withEffect)
		{
			deathEffect.CurrentColor = CurrentColor;
			deathEffect.Disable(gameObject, spriteRenderer, circleCollider2D);
		}
		else
		{
			gameObject.SetActive(false);
		}

		OnDisable?.Invoke(this);
	}

	public void Enable()
	{
		Enabled = true;
		gameObject.SetActive(true);
		spriteRenderer.enabled = true;
		spawnEffect.CurrentColor = CurrentColor;

		spawnEffect.gameObject.SetActive(true);
		spawnEffect.Play(spriteRenderer, circleCollider2D);
		rigidB.constraints = RigidbodyConstraints2D.None;
		rigidB.velocity = Vector2.zero;
		EnableTrail(SavingController.TrailIndex);
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

	public void Shoot(Vector2 velocity)
	{
		rigidB.velocity = Vector2.zero;
		rigidB.velocity = velocity;
	}

	private void EnableTrail(int index)
	{
		foreach (Transform trail in trailsContainer)
		{
			trail.gameObject.SetActive(false);
		}

		var currentTrail = trailsContainer.GetChild(index);
		currentTrail.gameObject.SetActive(true);
		currentTrail.GetComponent<BallTrailRenderer>().SetColor(CurrentColor);
	}
}

public enum ObjectSide
{
	Right,
	Left
}
