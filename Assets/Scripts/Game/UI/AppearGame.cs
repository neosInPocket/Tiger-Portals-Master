using System;
using TMPro;
using UnityEngine;

public class AppearGame : MonoBehaviour
{
	[SerializeField] private TMP_Text text;
	[SerializeField] private Animator animator;
	[SerializeField] private string[] texts;
	private int currentState;
	private Action EndAction;

	public void Play(Action endAction)
	{
		EndAction = endAction;
		gameObject.SetActive(true);
		currentState = 0;
		OnCycleEnd();
	}

	public void OnCycleEnd()
	{
		if (currentState >= texts.Length)
		{
			EndAction();
			gameObject.SetActive(false);
			return;
		}

		text.text = texts[currentState];
		currentState++;
		animator.SetTrigger("Appear");
	}
}
