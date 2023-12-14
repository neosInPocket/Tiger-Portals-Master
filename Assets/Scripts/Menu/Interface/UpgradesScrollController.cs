using UnityEngine;
using UnityEngine.UI;

public class UpgradesScrollController : MonoBehaviour
{
	[SerializeField] private ScrollRect scrollRect;
	[SerializeField] private Image leftArrow;
	[SerializeField] private Image rightArrow;

	private void Start()
	{
		scrollRect.onValueChanged.AddListener(OnValueChanged);

		OnValueChanged(Vector2.zero);
	}

	private void OnValueChanged(Vector2 position)
	{
		var color = leftArrow.color;

		color.a = position.x;
		leftArrow.color = color;

		color.a = 1 - position.x;
		rightArrow.color = color;
	}
}
