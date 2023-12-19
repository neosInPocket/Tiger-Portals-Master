using UnityEngine;

public class SavingController : MonoBehaviour
{
	public static int CurrentProgress;
	public static int CoinsAmount;
	public static int DiamondsAmount;
	public static int BallsSpeed;
	public static int DiamondSpawnChance;
	public static int TrailIndex;
	public static int AllTimeScore;
	public static float MusicVolume;
	public static float SFXVolume;
	public static int TutorialPassed;


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
		PlayerPrefs.SetInt("DiamondSpawnChance", DiamondSpawnChance);
		PlayerPrefs.SetInt("TrailIndex", TrailIndex);
		PlayerPrefs.SetInt("AllTimeScore", AllTimeScore);
		PlayerPrefs.SetInt("TutorialPassed", TutorialPassed);
		PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
		PlayerPrefs.SetFloat("SFXVolume", SFXVolume);

		PlayerPrefs.Save();
	}

	public static void Load()
	{
		CurrentProgress = PlayerPrefs.GetInt("CurrentProgress", 1);
		CoinsAmount = PlayerPrefs.GetInt("CoinsAmount", 50);
		DiamondsAmount = PlayerPrefs.GetInt("DiamondsAmount", 1);
		BallsSpeed = PlayerPrefs.GetInt("BallsSpeed", 0);
		DiamondSpawnChance = PlayerPrefs.GetInt("DiamondSpawnChance", 0);
		TrailIndex = PlayerPrefs.GetInt("TrailIndex", 0);
		AllTimeScore = PlayerPrefs.GetInt("AllTimeScore", 0);
		TutorialPassed = PlayerPrefs.GetInt("TutorialPassed", 0);
		SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
		MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
	}

	private static void ClearData()
	{
		CurrentProgress = 1;
		CoinsAmount = 50;
		DiamondsAmount = 1;
		BallsSpeed = 0;
		DiamondSpawnChance = 0;
		TrailIndex = 0;
		MusicVolume = 1f;
		SFXVolume = 1f;
		AllTimeScore = 0;
		TutorialPassed = 0;
		Save();
	}
}
