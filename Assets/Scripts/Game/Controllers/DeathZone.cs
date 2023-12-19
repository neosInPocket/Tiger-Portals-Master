using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeathZone : MonoBehaviour
{
	[SerializeField] private float yPositionScreenSizeRelative;
	[SerializeField] private float xPositionScreenSizeRelative;
	[SerializeField] private ParticleSystemRenderer pRenderer;
	[SerializeField] private BoxCollider2D boxCollider;
	[SerializeField] private bool flipY;
	[SerializeField] private GameProcess gameProcess;

	private void Start()
	{
		var screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		transform.position = new Vector2(2 * screenSize.x * xPositionScreenSizeRelative - screenSize.x, 2 * screenSize.y * yPositionScreenSizeRelative - screenSize.y);
		boxCollider.size = new Vector2(pRenderer.mesh.bounds.size.x * 5, pRenderer.mesh.bounds.size.z) * 3.54f;
		boxCollider.offset = new Vector2(0, boxCollider.size.y / 2);

		if (flipY)
		{
			var localScale = transform.localScale;
			localScale.y *= -1;
			transform.localScale = localScale;
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<Ball>(out Ball ball))
		{
			ball.Disable(true);
			gameProcess.IncreasePoints(-1);
		}
	}
}
