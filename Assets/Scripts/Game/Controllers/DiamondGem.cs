using System.Collections;
using UnityEngine;

public class DiamondGem : MonoBehaviour
{
	[SerializeField] private GameObject deathEffect;
	[SerializeField] private float speed;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private SpriteRenderer spriteRenderer;
	private bool isDead;

	private void FixedUpdate()
	{
		var position = transform.position;
		position.y -= speed * Time.fixedDeltaTime;
		transform.position = position;

		var rotation = transform.eulerAngles;
		rotation.z += rotationSpeed * Time.fixedDeltaTime;
		transform.eulerAngles = rotation;
	}

	public void Death()
	{
		if (isDead) return;
		isDead = true;
		StartCoroutine(DeathEffect());
	}

	private IEnumerator DeathEffect()
	{
		spriteRenderer.enabled = false;
		var effect = Instantiate(deathEffect, transform.position, Quaternion.identity, transform);
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}
}
