using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlRetreatState : State
{
	public OwlEnemyController enemyController;
	public OwlIdleState idleState;

	[HideInInspector]
	public Vector3 velocity;
	[HideInInspector]
	public float timer;

	private bool timedOut = false;
	private bool aboveHome = false;
	private CharacterController controller;
	private Transform graphics;

	private void Start()
	{
		controller = transform.parent.parent.GetComponent<CharacterController>();
		graphics = transform.parent.parent.Find("Graphics");
	}

	public override State RunCurrentState()
	{
		if (!aboveHome)
		{
			velocity += 30.0f * Vector3.up * Time.deltaTime * Time.deltaTime;
			controller.Move(velocity);
			timer += Time.deltaTime;

			//graphics.position = Vector3.MoveTowards(graphics.position, 0.9f * Vector3.back, 0.5f);

			if (timer > 10.0f)
			{
				aboveHome = true;
				transform.parent.parent.position = idleState.home.position + 400.0f * Vector3.up;
			}
		}
		else
		{
			transform.parent.parent.position = Vector3.MoveTowards(transform.position, idleState.home.position, 1.5f);
			if (Vector3.Distance(transform.parent.parent.position, idleState.home.position) < 0.1f)
			{
				timedOut = true;
			}
		}

		if (timedOut)
		{
			timer = 0.0f;
			enemyController.SetIsFlying(false);
			transform.parent.parent.transform.position = idleState.home.position;
			aboveHome = false;
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
