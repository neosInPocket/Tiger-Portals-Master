using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPortalsController : RouteObject
{
	[SerializeField] private Vector2 spawnDelay;
	[SerializeField] private BallsPool ballsPool;
	[SerializeField] private float[] ballSpeed;

	public override bool Enabled
	{
		get => isEnabled;
		set => isEnabled = value;
	}

	public override bool Freezed
	{
		get => isFreezed;
		set => isFreezed = value;
	}

	private bool isSpawned;
	private List<ShooterPortal> portals;

	private void Update()
	{
		if (!Enabled) return;
		if (isSpawned) return;

		StartCoroutine(SpawnRoutine());
	}

	private IEnumerator SpawnRoutine()
	{
		if (isFreezed) yield break;

		isSpawned = true;
		Ball ball = default;

		var randomInt = Random.Range(0, 2);
		if (randomInt == 0)
		{
			ball = ballsPool.Instantiate(portals[0].transform.position);
		}
		else
		{
			ball = ballsPool.Instantiate(portals[1].transform.position);
		}

		ball.SetSpeed(ballSpeed[SavingController.BallsSpeed]);
		yield return new WaitForSeconds(Random.Range(spawnDelay.x, spawnDelay.y));

		isSpawned = false;
	}

	public void SetPortals(List<ShooterPortal> shooterPortals)
	{
		portals = shooterPortals;
	}

	public override void Restart()
	{
		Enabled = false;
	}
}
