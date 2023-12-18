using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesController : MonoBehaviour
{
	[SerializeField] private RandomColors randomColors;
	private List<PointZone> pointZones;
	private List<TriggerBarrier> barriers;

	public void SetZones(List<PointZone> zones, List<TriggerBarrier> tirggerBarriers)
	{
		pointZones = zones;
		barriers = tirggerBarriers;
		SetRandomZonesColors();
	}

	private void SetRandomZonesColors()
	{
		List<Color> shuffled1 = randomColors.GetShuffeledList();

		for (int i = 0; i < 3; i++)
		{
			pointZones[i].Color = shuffled1[i];
			barriers[i].Color = shuffled1[i];
		}

		List<Color> shuffled2 = randomColors.GetShuffeledList();

		for (int i = 3; i < 6; i++)
		{
			pointZones[i].Color = shuffled2[i];
			barriers[i].Color = shuffled2[i];
		}
	}
}
