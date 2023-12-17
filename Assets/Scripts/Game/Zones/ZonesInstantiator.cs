using System.Collections.Generic;
using UnityEngine;

public class ZonesInstantiator : RouteObject
{
	[Header("Prefabs")]
	[SerializeField] private TriggerBarrier barrier;
	[SerializeField] private PointZone pointZonePrefab;

	[Header("Positions")]
	[SerializeField] private Vector2 xAnchors;
	[SerializeField] private Vector2 yAnchors;
	[SerializeField] private float barrierWidthScreenSizeRelative;
	[SerializeField] private ZonesController zonesController;
	private Vector2 screenSize;

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

	public override void Restart()
	{
		SpawnBarriers();
		SpawnZones();
	}

	private void SpawnBarriers()
	{
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

		float barrierWidth = barrierWidthScreenSizeRelative * screenSize.x * 2;

		Vector2 leftBarrierPosition = new Vector2(-barrierWidth / 2, 0);
		Vector2 rightBarrierPosition = new Vector2(barrierWidth / 2, 0);
		var leftBarrier = Instantiate(barrier, leftBarrierPosition, Quaternion.identity, transform);
		var rightBarrier = Instantiate(barrier, rightBarrierPosition, Quaternion.identity, transform);

		float barrierHeight = (yAnchors.y - yAnchors.x) * screenSize.y * 2;
		Vector2 barrierSize = new Vector2(barrierWidth, barrierHeight);
		leftBarrier.Size = barrierSize;
		rightBarrier.Size = barrierSize;
	}

	private void SpawnZones()
	{
		List<PointZone> zones = new List<PointZone>();
		float allZoneWidth = 2 * (xAnchors.y - xAnchors.x) / 2 * screenSize.x;
		float barrierWidth = 2 * barrierWidthScreenSizeRelative * screenSize.x;
		float zoneWidth = allZoneWidth - 2 * barrierWidth;
		float zoneHeight = 2 * (yAnchors.y - yAnchors.x) * screenSize.y / 3;
		float yStart = 2 * yAnchors.x * screenSize.y - screenSize.y + zoneHeight / 2;

		for (int i = 0; i < 3; i++)
		{
			Vector2 position = new Vector2(-barrierWidth / 2, yStart + zoneHeight * i);
			var zone = Instantiate(pointZonePrefab, transform);
			zone.Size = new Vector2(zoneWidth, zoneHeight);
			zone.transform.position = position;
		}
	}
}
