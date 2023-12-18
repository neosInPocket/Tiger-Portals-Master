using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcess : MonoBehaviour
{
	[SerializeField] private StatusBar statusBar;
	private EntryPoint entryPoint;

	public void Initialize(EntryPoint entry)
	{
		entryPoint = entry;
		entryPoint.EnableAll(true);
		entryPoint.FreezeAll(false);
	}

}
