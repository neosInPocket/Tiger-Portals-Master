using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallsPool : MonoBehaviour
{
	[SerializeField] private Ball prefab;
	[SerializeField] private int initialSize;
	[SerializeField] private RandomColors randomColors;
	private List<Ball> balls;

	private void Start()
	{
		balls = new List<Ball>();

		for (int i = 0; i < initialSize; i++)
		{
			var ball = Instantiate(prefab, transform);
			ball.Disable(false);
			balls.Add(ball);
		}
	}

	public Ball Instantiate(Vector2 position)
	{
		var activeBall = balls.FirstOrDefault(x => !x.gameObject.activeSelf);
		if (activeBall != null)
		{
			activeBall.Enable();
			activeBall.CurrentColor = randomColors.GetRandomColor();
			activeBall.transform.position = position;
			return activeBall;
		}
		else
		{
			var ball = Instantiate(prefab, position, Quaternion.identity, transform);
			activeBall.CurrentColor = randomColors.GetRandomColor();
			balls.Add(ball);
			return ball;
		}
	}

	public Ball Instantiate()
	{
		return Instantiate(Vector2.zero);
	}

	public void EnableAll(bool value, bool withEffects)
	{
		foreach (var ball in balls)
		{
			if (value)
			{
				ball.Enable();
			}
			else
			{
				ball.Disable(withEffects);
			}
		}
	}

	public void FreezeAll(bool value)
	{
		foreach (var ball in balls)
		{
			if (value)
			{
				ball.Freeze();
			}
			else
			{
				ball.Unfreeze();
			}
		}
	}
}
