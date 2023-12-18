using System;
using System.ComponentModel;
using UnityEngine;

public class MainGameModule : MonoBehaviour
{
	[SerializeField] private ShowGameWindow showGameWindow;
	[SerializeField] private AppearGame appearGame;
	[SerializeField] private GameProcess gameProcess;
	[SerializeField] private EntryPoint entryPoint;
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
		gameProcess.Initialize(entryPoint);
	}
}
