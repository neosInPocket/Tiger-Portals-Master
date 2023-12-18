using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class ShowGameWindow : MonoBehaviour
{
	[SerializeField] private Transform firstArrow;
	[SerializeField] private Transform secondArrow;
	[SerializeField] private TMP_Text text;
	[SerializeField] private Animator animator;
	[SerializeField] private TutorialAction[] actions;
	[SerializeField] private Transform container;
	private Action OnNext;
	private int currentActionIndex;

	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}

	public void Play(Action onNext)
	{
		gameObject.SetActive(true);

		currentActionIndex = 0;
		OnNext = onNext;
		Touch.onFingerDown += NextAction;
		FireAction(ref currentActionIndex);
	}

	private void NextAction(Finger finger)
	{
		if (currentActionIndex >= actions.Length)
		{
			Touch.onFingerDown -= NextAction;
			OnEnd();
			return;
		}

		FireAction(ref currentActionIndex);
	}

	private void OnEnd()
	{
		animator.SetTrigger("Hide");
	}

	public void OnAnimatorAction()
	{
		OnNext();
		gameObject.SetActive(false);
	}

	private void FireAction(ref int index)
	{
		TutorialAction currentAction = actions[index];

		firstArrow.gameObject.SetActive(currentAction.firstArrowEnabled);
		secondArrow.gameObject.SetActive(currentAction.secondArrowEnabled);

		if (currentAction.firstArrowTarget != null)
		{
			firstArrow.position = currentAction.secondArrowTarget.position;
		}

		if (currentAction.secondArrowTarget != null)
		{
			secondArrow.position = currentAction.firstArrowTarget.position;
		}

		var firstArrowAngles = firstArrow.rotation.eulerAngles;
		firstArrowAngles.z = currentAction.firstArrowRotation;
		var secondArrowAngles = secondArrow.rotation.eulerAngles;
		secondArrowAngles.z = currentAction.secondArrowRotation;

		firstArrow.eulerAngles = firstArrowAngles;
		secondArrow.eulerAngles = secondArrowAngles;

		text.text = currentAction.characterText;

		if (currentAction.tutorialContainerTarget != null)
		{
			container.transform.position = currentAction.tutorialContainerTarget.position;
		}

		index++;
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= NextAction;
	}
}

[Serializable]
public class TutorialAction
{
	[SerializeField] public bool firstArrowEnabled;
	[SerializeField] public bool secondArrowEnabled;
	[SerializeField] public Transform firstArrowTarget;
	[SerializeField] public Transform secondArrowTarget;
	[SerializeField] public float firstArrowRotation;
	[SerializeField] public float secondArrowRotation;
	[SerializeField] public string characterText;
	[SerializeField] public Transform tutorialContainerTarget;
}
