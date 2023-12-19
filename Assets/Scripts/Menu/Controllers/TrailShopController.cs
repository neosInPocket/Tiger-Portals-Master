using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TrailShopController : Refreshable
{
	[SerializeField] private List<GameObject> trails;
	[SerializeField] private RectTransform container;
	[SerializeField] private RectTransform ball;
	[SerializeField] private float maxYValue;
	[SerializeField] private float maxXValue;
	[SerializeField] private float verticalSpeed;
	[SerializeField] private float horizontalSpeed;
	[SerializeField] private Image purchasedImage;
	[SerializeField] private TMP_Text costText;
	[SerializeField] private Button leftArrowButton;
	[SerializeField] private Button rightArrowButton;
	[SerializeField] private Button purchaseButton;
	[SerializeField] private UIRefreshController refresher;
	[SerializeField] private TMP_Text trailNameText;
	[SerializeField] private string[] trailNames;
	private float currentTime;
	private float normalizedVerticalPosition
	{
		get => m_normalizedVerticalPosition;
		set
		{
			var localPosition = ball.localPosition;
			localPosition.y = -value * container.rect.y;
			ball.localPosition = localPosition;
			m_normalizedVerticalPosition = value;
		}
	}

	private float normalizedHorizontalPosition
	{
		get => m_normalizedHorizontalPosition;
		set
		{
			var localPosition = ball.localPosition;
			localPosition.x = -value * container.rect.x;
			ball.localPosition = localPosition;
			m_normalizedHorizontalPosition = value;
		}
	}

	private float m_normalizedVerticalPosition;
	private float m_normalizedHorizontalPosition;

	private int currentTrailIndex;

	private void Start()
	{
		currentTime = 0;
	}

	public override void Refresh()
	{
		currentTrailIndex = SavingController.TrailIndex;
		DisableAllTrails();
		trails[currentTrailIndex].gameObject.SetActive(true);
		RefreshButton();
	}

	public void RefreshButton()
	{
		trailNameText.text = trailNames[currentTrailIndex];

		if (currentTrailIndex > 5)
		{
			rightArrowButton.interactable = false;
		}
		else
		{
			rightArrowButton.interactable = true;
		}

		if (currentTrailIndex <= 0)
		{
			leftArrowButton.interactable = false;
		}
		else
		{
			leftArrowButton.interactable = true;
		}

		var cost = GetTrailCost(currentTrailIndex);

		if (currentTrailIndex <= SavingController.TrailIndex)
		{
			PurchasedButton();
			return;
		}

		if (currentTrailIndex - 1 == SavingController.TrailIndex)
		{
			if (SavingController.DiamondsAmount - GetTrailCost(currentTrailIndex) < 0)
			{
				NotEnoughMoneyButton(cost);
			}
			else
			{
				NormalButton(cost);
			}
		}
		else
		{
			NotEnoughMoneyButton(cost);
		}


	}

	private void EnableButton(bool enabled, bool purchased, bool costEnabled, int cost = 0)
	{
		purchaseButton.interactable = enabled;
		purchasedImage.enabled = purchased;
		costText.gameObject.SetActive(costEnabled);
		costText.text = cost.ToString();
	}

	private void PurchasedButton()
	{
		EnableButton(false, true, false);
	}

	private void NotEnoughMoneyButton(int cost)
	{
		EnableButton(false, false, true, cost);
	}

	private void NormalButton(int cost)
	{
		EnableButton(true, false, true, cost);
	}

	public void Increase(int value)
	{
		currentTrailIndex += value;
		RefreshButton();

		DisableAllTrails();
		trails[currentTrailIndex].gameObject.SetActive(true);
	}

	private void Update()
	{
		normalizedVerticalPosition = maxYValue * Mathf.Sin(currentTime * verticalSpeed);
		normalizedHorizontalPosition = maxXValue * Mathf.Sin(currentTime * horizontalSpeed);
		currentTime += Time.deltaTime;
	}

	private void DisableAllTrails()
	{
		foreach (var trail in trails)
		{
			trail.gameObject.SetActive(false);
		}
	}

	public int GetTrailCost(int index)
	{
		return index;
	}

	public void Purchase()
	{
		SavingController.DiamondsAmount -= GetTrailCost(currentTrailIndex);
		SavingController.TrailIndex = currentTrailIndex;
		SavingController.Save();
		RefreshButton();
		refresher.Refresh();
	}
}
