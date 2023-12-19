using System;
using TMPro;
using UnityEngine;

public class WinWindow : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private GameProcess gameProcess;
	[SerializeField] private TMP_Text result;
	[SerializeField] private TMP_Text coinsText;
	[SerializeField] private TMP_Text diamondsText;
	[SerializeField] private Transform fireworksContainer;
	private Action hideAction;

	public void Play(int coins, int diamonds)
	{
		gameObject.SetActive(true);

		if (coins == 0)
		{
			result.text = "YOU LOSE...";
			fireworksContainer.gameObject.SetActive(false);
		}
		else
		{
			result.text = "YOU WIN!!";
			fireworksContainer.gameObject.SetActive(false);
		}

		coinsText.text = coins.ToString();
		diamondsText.text = diamonds.ToString();

	}

	public void Hide()
	{
		animator.SetTrigger("hide");
		hideAction = () => gameProcess.Restart();
	}

	public void Exit()
	{
		animator.SetTrigger("hide");
		hideAction = () => gameProcess.Quit();
	}

	public void OnHideAction()
	{
		hideAction();
		gameObject.SetActive(false);
	}
}
