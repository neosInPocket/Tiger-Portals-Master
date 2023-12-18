using UnityEngine;

public class EntryPoint : MonoBehaviour
{
	[SerializeField] private RouteObject[] routeObjects;
	[SerializeField] private MainGameModule mainGameModule;

	private void Start()
	{
		foreach (var obj in routeObjects)
		{
			obj.Enabled = false;
			obj.Restart();
			obj.Freezed = true;
		}

		mainGameModule.Process(() => Debug.Log("ENDED"));
	}
}
