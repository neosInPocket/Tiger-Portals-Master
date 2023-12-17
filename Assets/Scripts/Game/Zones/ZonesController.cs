using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesController : MonoBehaviour
{
	private List<PointZone> pointZones;

	public void SetZones(List<PointZone> zones)
	{
		pointZones = zones;
	}
}
