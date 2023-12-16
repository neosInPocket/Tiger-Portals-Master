using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetScreenController : MonoBehaviour
{
	[SerializeField] private AnimationCurve transparencyCurve;
	[SerializeField] private AnimationCurve speedCurve;
	[SerializeField] private float speedAmplitude;
	[SerializeField] private float epsilonThreshold;
	[SerializeField] private List<TargetScreenTransition> transitions;
	[SerializeField] private UIRefreshController refreshController;
	[SerializeField] private float fadeTime;
	[SerializeField] private CanvasGroup menuScreenTransition;

	private void Start()
	{
		EvaluateCurve(0);
	}

	public void MoveToScreen(TargetScreenTransition target)
	{
		refreshController.Refresh();
		StopAllCoroutines();
		StartCoroutine(MoveTo(target));
	}

	private IEnumerator MoveTo(TargetScreenTransition target)
	{
		var targetPosition = -target.startZ;
		var distance = targetPosition - transform.position.z;
		float magnitude = 1;
		int direction = (int)(distance / Mathf.Abs(distance));
		float currentDistance = distance;
		Vector3 currentPosition = transform.position;

		if (direction > 0)
		{
			while (transform.position.z < targetPosition)
			{
				currentPosition.z += Time.deltaTime * speedCurve.Evaluate(magnitude) * speedAmplitude;
				transform.position = currentPosition;
				EvaluateCurve(transform.position.z);

				currentDistance = targetPosition - transform.position.z;
				magnitude = Mathf.Abs(targetPosition - transform.position.z) / Mathf.Abs(distance);
				yield return new WaitForFixedUpdate();
			}
		}

		if (direction < 0)
		{
			while (transform.position.z > targetPosition)
			{
				currentPosition.z -= Time.deltaTime * speedCurve.Evaluate(magnitude) * speedAmplitude;
				transform.position = currentPosition;
				EvaluateCurve(transform.position.z);

				currentDistance = targetPosition - transform.position.z;
				magnitude = Mathf.Abs(targetPosition - transform.position.z) / Mathf.Abs(distance);
				yield return new WaitForFixedUpdate();
			}
		}

		currentPosition.z = targetPosition;
		transform.position = currentPosition;
	}

	public void EvaluateCurve(float time)
	{
		foreach (var screen in transitions)
		{
			screen.SetTransparency(transparencyCurve);
		}
	}

	public void PlayTransition()
	{
		StartCoroutine(PlayCoroutine());
	}

	private IEnumerator PlayCoroutine()
	{
		float currentTime = 0;

		while (currentTime < fadeTime)
		{
			menuScreenTransition.alpha = 1 - currentTime / fadeTime;
			currentTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		LoadPlayScene();
	}

	private void LoadPlayScene()
	{
		SceneManager.LoadScene("PlayScene");
	}
}
