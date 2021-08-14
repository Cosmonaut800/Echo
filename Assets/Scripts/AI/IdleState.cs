using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
	public ChaseState chaseState;
	public CharacterController controller;
	public float speed = 5.0f;
	public Transform home;

	public Transform targetedPosition;

	private bool detectPlayer = false;
	private int walkFrame = 0;
	private bool atHome = false;

	public override State RunCurrentState()
	{
		Vector3 target = home.position;
		Vector3 velocity;

		if(atHome)
		{
			Vector3 direction = transform.position - home.position;
			direction.Normalize();

			target = -Vector3.Cross(Vector3.up, direction);
			target = (20.0f * direction) + target;
			target += home.position;
		}
		else
		{
			CheckAtHome();
		}

		targetedPosition.position = target;

		velocity = target - transform.position;
		velocity.Normalize();
		velocity *= speed * Time.deltaTime;
		velocity.y = -5.0f;

		controller.Move(velocity);

		if (detectPlayer)
		{
			return chaseState;
		}
		else
		{
			return this;
		}
	}

	private bool CheckAtHome()
	{
		atHome = (Vector3.Distance(transform.position, home.position) < 2.0f);
		return atHome;
	}

	public void SetDetectPlayer(bool newDetectPlayer)
	{
		detectPlayer = newDetectPlayer;
	}
}
