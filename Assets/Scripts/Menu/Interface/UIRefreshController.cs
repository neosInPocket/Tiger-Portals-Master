using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIRefreshController : MonoBehaviour
{
	[SerializeField] private List<Refreshable> refreshables;

	private void Start()
	{
		Refresh();
	}

	public void Refresh()
	{
		foreach (var refreshable in refreshables)
		{
			refreshable.Refresh();
		}
	}
}
