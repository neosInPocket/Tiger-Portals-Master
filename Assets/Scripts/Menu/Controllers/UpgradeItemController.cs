using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemController : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private TMP_Text valueText;
	[SerializeField] private Image deniedImage;
	[SerializeField] private PurchaseType purchaseType;
	public PurchaseType Type => purchaseType;

	public void CheckEnabled(bool enabled)
	{
		button.interactable = enabled;
		valueText.gameObject.SetActive(enabled);

		deniedImage.gameObject.SetActive(!enabled);
	}
}


