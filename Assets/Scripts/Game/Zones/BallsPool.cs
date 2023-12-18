using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallsPool : MonoBehaviour
{
	[SerializeField] private Ball prefab;
	[SerializeField] private int initialSize;
	private List<Ball> balls;

	private void Start()
	{
		balls = new List<Ball>();

		for (int i = 0; i < initialSize; i++)
		{
			var ball = Instantiate(prefab, transform);
			ball.gameObject.SetActive(false);
			balls.Add(ball);
		}
	}

	public Ball Instantiate(Vector2 position)
	{
		var activeBall = balls.FirstOrDefault(x => x.gameObject.activeSelf);
		if (activeBall != null)
		{
			activeBall.gameObject.SetActive(true);
			activeBall.transform.position = position;
			return activeBall;
		}
		else
		{
			var ball = Instantiate(prefab, position, Quaternion.identity, transform);
			balls.Add(ball);
			return ball;
		}
	}

	public Ball Instantiate()
	{
		return Instantiate(Vector2.zero);
	}
}
