using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchInputController : RouteObject
{
	public Action<bool> OnFingerDown;
	public Action<Vector2> OnFingerDownPosition;

	public override bool Enabled
	{
		get => isEnabled;
		set
		{
			isEnabled = value;
			if (value)
			{
				Touch.onFingerDown += OnFingerTouch;
			}
			else
			{
				Touch.onFingerDown += OnFingerTouch;
			}
		}
	}

	public override bool Freezed
	{
		get => isFreezed;
		set => Enabled = value;
	}

	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}

	private void OnFingerTouch(Finger finger)
	{
		if (finger.screenPosition.x < Screen.width / 2)
		{
			OnFingerDown?.Invoke(false);
		}
		else
		{
			OnFingerDown?.Invoke(true);
		}

		var worldPos = Camera.main.ScreenToWorldPoint(finger.screenPosition);
		OnFingerDownPosition?.Invoke(worldPos);
	}

	public override void Restart()
	{
		Enabled = false;
	}
}
