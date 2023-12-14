using UnityEngine;

public class TargetScreenTransition : MonoBehaviour
{
	[SerializeField] private CanvasGroup canvasGroup;
	public float startZ { get; set; }

	private void Awake()
	{
		startZ = transform.position.z;
	}

	public void SetTransparency(AnimationCurve curve)
	{
		canvasGroup.alpha = curve.Evaluate(transform.position.z);
	}
}
