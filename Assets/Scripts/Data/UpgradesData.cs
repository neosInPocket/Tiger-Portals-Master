using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades Data")]
public class UpgradesData : ScriptableObject
{
	[SerializeField] private List<UpgradeInfo> upgradeInfos;
	public List<UpgradeInfo> UpgradeInfos => upgradeInfos;
}

[Serializable]
public class UpgradeInfo
{
	[SerializeField] private PurchaseType purchaseType;
	[SerializeField] private CurrencyType currencyType;
	[SerializeField] private int cost;

	public PurchaseType PurchaseType => purchaseType;
	public CurrencyType CurrencyType => currencyType;
	public int Cost => cost;
}

public enum PurchaseType
{
	BallsSpeed,
	ZoneHeight
}

public enum CurrencyType
{
	Coins,
	Diamonds
}
