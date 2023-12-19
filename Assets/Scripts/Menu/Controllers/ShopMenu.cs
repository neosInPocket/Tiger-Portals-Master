using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopMenu : Refreshable
{
	[SerializeField] private InfoPanel infoPanel;
	[SerializeField] private List<UpgradeItemController> upgradeItemControllers;
	[SerializeField] private UpgradesData upgradesData;
	[SerializeField] private UIRefreshController uIRefreshController;

	public override void Refresh()
	{
		foreach (var item in upgradeItemControllers)
		{
			PurchaseType type = item.Type;
			var upgradeInfo = upgradesData.UpgradeInfos.FirstOrDefault(x => x.PurchaseType == type);
			bool isEnabled = default;

			if (upgradeInfo.CurrencyType == CurrencyType.Coins)
			{
				isEnabled = SavingController.CoinsAmount >= upgradeInfo.Cost && SavingController.BallsSpeed < 3;
			}
			else
			{
				isEnabled = SavingController.DiamondsAmount >= upgradeInfo.Cost && SavingController.DiamondSpawnChance < 3;
			}

			item.CheckEnabled(isEnabled);
		}

		infoPanel.Refresh();
	}

	public void Purchase(UpgradeItemController item)
	{
		var upgradeInfo = upgradesData.UpgradeInfos.FirstOrDefault(x => x.PurchaseType == item.Type);

		if (upgradeInfo.CurrencyType == CurrencyType.Coins)
		{
			SavingController.CoinsAmount -= upgradeInfo.Cost;
		}
		else
		{
			SavingController.DiamondsAmount -= upgradeInfo.Cost;
		}

		if (upgradeInfo.PurchaseType == PurchaseType.BallsSpeed)
		{
			SavingController.BallsSpeed++;
		}
		else
		{
			SavingController.DiamondSpawnChance++;
		}

		SavingController.Save();
		uIRefreshController.Refresh();
	}
}
