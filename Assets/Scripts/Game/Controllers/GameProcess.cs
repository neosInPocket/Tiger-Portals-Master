using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProcess : MonoBehaviour
{
	[SerializeField] private StatusBar statusBar;
	[SerializeField] private WinWindow winWindow;
	private EntryPoint entryPoint;
	private int currentPoints;
	private int maxPoints;
	private int reward;
	public int CurrentDiamonds { get; set; }

	public void Initialize(EntryPoint entry)
	{
		maxPoints = GetPoints();
		currentPoints = maxPoints / 2;
		reward = GetReward();
		CurrentDiamonds = 0;

		entryPoint = entry;
		entryPoint.EnableAll(true);
		entryPoint.FreezeAll(false);
		statusBar.Refresh((float)currentPoints / (float)maxPoints);
	}

	public void IncreasePoints(int value)
	{
		currentPoints += value;
		if (currentPoints >= maxPoints)
		{
			currentPoints = maxPoints;
			entryPoint.EnableAll(false);
			entryPoint.FreezeAll(true);
			winWindow.Play(reward, CurrentDiamonds);

			SavingController.CurrentProgress++;
			SavingController.CoinsAmount += reward;
			SavingController.AllTimeScore += maxPoints;
			SavingController.DiamondsAmount += CurrentDiamonds;
			SavingController.Save();
		}

		if (currentPoints <= 0)
		{
			currentPoints = 0;
			entryPoint.EnableAll(false);
			entryPoint.FreezeAll(true);
			winWindow.Play(0, 0);
		}

		statusBar.Refresh((float)currentPoints / (float)maxPoints);
	}

	private int GetPoints()
	{
		var x = SavingController.CurrentProgress + 1;
		return (int)(Mathf.Log(x * x * x * x * x * x * x * x * x * x) + 10);
	}

	private int GetReward()
	{
		var x = SavingController.CurrentProgress + 1;
		return (int)(Mathf.Log(x * x * x * x * x) + 10);
	}

	public void Restart()
	{
		SceneManager.LoadScene("PlayScene");
	}

	public void Quit()
	{
		SceneManager.LoadScene("MainScene");
	}

	public void StopGame()
	{
		entryPoint.FreezeAll(false);
		entryPoint.EnableAll(false);
	}
}
