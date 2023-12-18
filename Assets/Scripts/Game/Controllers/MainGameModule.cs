using System;
using UnityEngine;

public class MainGameModule : MonoBehaviour
{
	[SerializeField] private ShowGameWindow showGameWindow;
	[SerializeField] private AppearGame appearGame;
	private Action CheckAction;

	public void Process(Action onCheckAction)
	{
		CheckAction = onCheckAction;

		if (SavingController.TutorialPassed == 0)
		{
			SavingController.TutorialPassed = 1;
			SavingController.Save();
			showGameWindow.Play(OnShowEnd);
		}
		else
		{
			OnShowEnd();
		}
	}

	private void OnShowEnd()
	{
		appearGame.Play(OnAppearEnd);
	}

	private void OnAppearEnd()
	{
		Debug.Log("END");
	}
}
