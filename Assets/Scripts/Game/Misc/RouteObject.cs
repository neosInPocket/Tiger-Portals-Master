using UnityEngine;

public abstract class RouteObject : MonoBehaviour
{
	public abstract bool Enabled { get; set; }
	public abstract bool Freezed { get; set; }
	protected bool isEnabled;
	protected bool isFreezed;
	public abstract void Restart();
}
