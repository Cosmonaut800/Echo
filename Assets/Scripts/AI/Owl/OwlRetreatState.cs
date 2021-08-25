using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlRetreatState : State
{
	public OwlIdleState idleState;

	[HideInInspector]
	public Vector3 velocity;
	[HideInInspector]
	public float timer;

	private bool timedOut = false;
	private CharacterController controller;

	private void Start()
	{
		controller = transform.parent.parent.GetComponent<CharacterController>();
	}

	public override State RunCurrentState()
	{
		velocity += 30.0f * Vector3.up * Time.deltaTime * Time.deltaTime;
		controller.Move(velocity);
		timer += Time.deltaTime;

		if (timer > 10.0f)
		{
			timedOut = true;
		}

		if (timedOut)
		{
			transform.parent.parent.transform.position = idleState.home.position;
			timedOut = false;
			idleState.SetDetectPlayer(false);
			return idleState;
		}
		else
		{
			return this;
		}
	}
}
