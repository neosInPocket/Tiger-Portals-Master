using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesController : MonoBehaviour
{
	private List<PointZone> pointZones;
	private List<TriggerBarrier> barriers;

	public void SetZones(List<PointZone> zones, List<TriggerBarrier> tirggerBarriers)
	{
		pointZones = zones;
		barriers = tirggerBarriers;
	}
}
