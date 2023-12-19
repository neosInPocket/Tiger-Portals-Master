using TMPro;
using UnityEngine;

public class StatsContainer : Refreshable
{
	[SerializeField] private TMP_Text resultText;
	[SerializeField] private StatsType statsType;

	public override void Refresh()
	{
		if (statsType == StatsType.AllTimeScore)
		{
			resultText.text = SavingController.AllTimeScore.ToString();
		}

		if (statsType == StatsType.BallsSpeed)
		{
			resultText.text = $"{SavingController.BallsSpeed}/3";
		}

		if (statsType == StatsType.ZoneHeight)
		{
			resultText.text = $"{SavingController.DiamondSpawnChance}/3";
		}
	}

	private enum StatsType
	{
		AllTimeScore,
		BallsSpeed,
		ZoneHeight
	}
}


