using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DiamondSpawner : RouteObject
{
	[SerializeField] private DiamondGem prefab;
	[SerializeField] private GameProcess gameProcess;
	[SerializeField] private Vector2[] delays;
	private Vector2 delay;

	public override bool Enabled
	{
		get => isEnabled;
		set
		{
			isEnabled = value;
			if (!value)
			{
				StopAllCoroutines();
			}

			isSpawned = false;
		}
	}

	public override bool Freezed { get; set; }
	private Vector2 screenSize;
	private bool isSpawned;

	public override void Restart()
	{
		Enabled = false;
		Freezed = false;
	}

	private void Start()
	{
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		delay = delays[SavingController.DiamondSpawnChance];
	}

	private void Update()
	{
		if (!Enabled) return;
		if (isSpawned) return;

		StartCoroutine(Spawn());
	}

	private IEnumerator Spawn()
	{
		isSpawned = true;
		var rndX = Random.Range(3 * -screenSize.x / 4, 3 * screenSize.x / 4);
		var position = new Vector2(rndX, screenSize.y + screenSize.y / 4);
		Instantiate(prefab, position, Quaternion.identity, transform);

		yield return new WaitForSeconds(Random.Range(delay.x, delay.y));
		isSpawned = false;
	}
}
