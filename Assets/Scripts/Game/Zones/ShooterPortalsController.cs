using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ShooterPortalsController : RouteObject
{
	[SerializeField] private Vector2 spawnDelay;
	[SerializeField] private BallsPool ballsPool;
	[SerializeField] private float[] ballSpeed;
	[SerializeField] private TouchInputController touchInputController;
	[SerializeField] private float shootSpeed;
	[SerializeField] private GameProcess gameProcess;

	private List<Ball> leftBalls;
	private List<Ball> rightBalls;

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

	private void Start()
	{
		touchInputController.OnFingerDown += OnFingerDown;
		leftBalls = new List<Ball>();
		rightBalls = new List<Ball>();
	}

	private void OnFingerDown(bool leftSide, Vector2 position)
	{
		var raycast = Physics2D.RaycastAll(position, Vector3.forward);
		var diamond = raycast.FirstOrDefault(x => x.collider.GetComponent<DiamondGem>() != null);

		if (diamond.collider != null)
		{
			var diamondGem = diamond.collider.GetComponent<DiamondGem>();

			if (diamondGem != null)
			{
				diamondGem.Death();
				gameProcess.CurrentDiamonds++;
				return;
			}
		}


		if (leftSide)
		{
			Ball highestBall = leftBalls.OrderByDescending(x => x.transform.position.y).FirstOrDefault();
			if (highestBall != null)
			{
				highestBall.Shoot(shootSpeed * Vector2.right);
			}
		}
		else
		{
			Ball highestBall = rightBalls.OrderByDescending(x => x.transform.position.y).FirstOrDefault();
			if (highestBall != null)
			{
				highestBall.Shoot(shootSpeed * Vector2.left);
			}
		}
	}

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
			ball.OnDisable += OnBallDisable;
			ball.Side = ObjectSide.Left;
			leftBalls.Add(ball);
		}
		else
		{
			ball = ballsPool.Instantiate(portals[1].transform.position);
			ball.OnDisable += OnBallDisable;
			ball.Side = ObjectSide.Right;
			rightBalls.Add(ball);
		}

		ball.SetSpeed(ballSpeed[SavingController.BallsSpeed]);
		yield return new WaitForSeconds(Random.Range(spawnDelay.x, spawnDelay.y));

		isSpawned = false;
	}

	private void OnBallDisable(Ball ball)
	{
		ball.OnDisable -= OnBallDisable;
		bool leftBall = leftBalls.Contains(ball);

		if (leftBall)
		{
			leftBalls.Remove(ball);
		}
		else
		{
			rightBalls.Remove(ball);
		}
	}

	public void SetPortals(List<ShooterPortal> shooterPortals)
	{
		portals = shooterPortals;
	}

	public override void Restart()
	{
		Enabled = false;
	}

	private void OnDestroy()
	{
		touchInputController.OnFingerDown -= OnFingerDown;
	}
}
