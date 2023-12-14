using TMPro;
using UnityEngine;

public class InfoPanel : Refreshable
{
	[SerializeField] private TMP_Text coinsText;
	[SerializeField] private TMP_Text diamondsText;

	public override void Refresh()
	{
		coinsText.text = SavingController.CoinsAmount.ToString();
		diamondsText.text = SavingController.DiamondsAmount.ToString();
	}
}
