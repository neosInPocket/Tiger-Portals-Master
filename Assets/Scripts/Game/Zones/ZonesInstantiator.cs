using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZonesInstantiator : RouteObject
{
	[Header("Prefabs")]
	[SerializeField] private TriggerBarrier barrier;
	[SerializeField] private PointZone pointZonePrefab;
	[SerializeField] private ShooterPortal shooterPortalPrefab;

	[Header("Positions")]
	[SerializeField] private Vector2 xAnchors;
	[SerializeField] private Vector2 yAnchors;
	[SerializeField] private float barrierWidthScreenSizeRelative;
	[SerializeField] private float portalXAnchor;
	[SerializeField] private ZonesController zonesController;
	[SerializeField] private ShooterPortalsController shooterController;
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
		var barriers = SpawnBarriers();
		var zones = SpawnZones();
		var portals = SpawnShooters();

		zonesController.SetZones(zones, barriers);
		shooterController.SetPortals(portals);
	}

	private List<TriggerBarrier> SpawnBarriers()
	{
		var leftBarriers = new List<TriggerBarrier>();
		var rightBarriers = new List<TriggerBarrier>();

		screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

		float barrierWidth = barrierWidthScreenSizeRelative * screenSize.x * 2;

		float barrierHeight = (yAnchors.y - yAnchors.x) * screenSize.y * 2 / 3;
		Vector2 barrierSize = new Vector2(barrierWidth, barrierHeight);

		float yStart = 2 * yAnchors.x * screenSize.y - screenSize.y + barrierHeight / 2;

		for (int i = 0; i < 3; i++)
		{
			Vector2 leftPosition = new Vector2(-barrierWidth / 2, yStart + barrierHeight * i);
			Vector2 rightPosition = new Vector2(barrierWidth / 2, yStart + barrierHeight * i);

			var leftBarrier = Instantiate(barrier, leftPosition, Quaternion.identity, zonesController.transform);
			var rightBarrier = Instantiate(barrier, rightPosition, Quaternion.identity, zonesController.transform);

			leftBarrier.Size = barrierSize;
			rightBarrier.Size = barrierSize;

			leftBarriers.Add(leftBarrier);
			rightBarriers.Add(rightBarrier);
		}

		return leftBarriers.Concat(rightBarriers).ToList();
	}

	private List<PointZone> SpawnZones()
	{
		List<PointZone> leftZones = new List<PointZone>();
		List<PointZone> rightZones = new List<PointZone>();

		float allZoneWidth = 2 * (xAnchors.y - xAnchors.x) / 2 * screenSize.x;
		float barrierWidth = 2 * barrierWidthScreenSizeRelative * screenSize.x;
		float zoneWidth = allZoneWidth - 2 * barrierWidth;
		float zoneHeight = 2 * (yAnchors.y - yAnchors.x) * screenSize.y / 3;
		float yStart = 2 * yAnchors.x * screenSize.y - screenSize.y + zoneHeight / 2;

		for (int i = 0; i < 3; i++)
		{
			Vector2 position = new Vector2(-barrierWidth / 2, yStart + zoneHeight * i);
			var zone = Instantiate(pointZonePrefab, zonesController.transform);
			zone.Size = new Vector2(zoneWidth, zoneHeight);
			zone.transform.position = position;

			leftZones.Add(zone);
		}

		for (int i = 0; i < 3; i++)
		{
			Vector2 position = new Vector2(barrierWidth / 2, yStart + zoneHeight * i);
			var zone = Instantiate(pointZonePrefab, zonesController.transform);
			zone.Size = new Vector2(-zoneWidth, zoneHeight);
			zone.transform.position = position;

			rightZones.Add(zone);
		}

		return leftZones.Concat(rightZones).ToList();
	}

	private List<ShooterPortal> SpawnShooters()
	{
		var portals = new List<ShooterPortal>();

		Vector2 leftPosition = new Vector2(2 * portalXAnchor * screenSize.x - screenSize.x, yAnchors.x * screenSize.y - screenSize.y);
		Vector2 rightPosition = new Vector2(-2 * portalXAnchor * screenSize.x + screenSize.x, yAnchors.x * screenSize.y - screenSize.y);

		var leftPortal = Instantiate(shooterPortalPrefab, shooterController.transform);
		var rightPortal = Instantiate(shooterPortalPrefab, shooterController.transform);

		leftPortal.transform.position = leftPosition;
		rightPortal.transform.position = rightPosition;

		portals.Add(leftPortal);
		portals.Add(rightPortal);

		return portals;
	}
}
