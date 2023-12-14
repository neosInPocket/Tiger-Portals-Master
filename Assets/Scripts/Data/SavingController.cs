using UnityEngine;

public class SavingController : MonoBehaviour
{
	public static int CurrentProgress;
	public static int CoinsAmount;
	public static int DiamondsAmount;
	public static int BallsSpeed;
	public static int ZoneHeight;
	public static int TrailIndex;


	[SerializeField] private bool defaults;

	private void Awake()
	{
		if (defaults)
		{
			ClearData();
		}

		Load();
	}


	public static void Save()
	{
		PlayerPrefs.SetInt("CurrentProgress", CurrentProgress);
		PlayerPrefs.SetInt("CoinsAmount", CoinsAmount);
		PlayerPrefs.SetInt("DiamondsAmount", DiamondsAmount);
		PlayerPrefs.SetInt("BallsSpeed", BallsSpeed);
		PlayerPrefs.SetInt("ZoneHeight", ZoneHeight);
		PlayerPrefs.SetInt("TrailIndex", TrailIndex);

		PlayerPrefs.Save();
	}

	public static void Load()
	{
		CurrentProgress = PlayerPrefs.GetInt("CurrentProgress", 1);
		CoinsAmount = PlayerPrefs.GetInt("CoinsAmount", 20);
		DiamondsAmount = PlayerPrefs.GetInt("DiamondsAmount", 1);
		BallsSpeed = PlayerPrefs.GetInt("BallsSpeed", 0);
		ZoneHeight = PlayerPrefs.GetInt("ZoneHeight", 0);
		TrailIndex = PlayerPrefs.GetInt("TrailIndex", 0);
	}

	private static void ClearData()
	{
		CurrentProgress = 1;
		CoinsAmount = 100;
		DiamondsAmount = 0;
		BallsSpeed = 0;
		ZoneHeight = 0;
		TrailIndex = 0;
		Save();
	}
}
