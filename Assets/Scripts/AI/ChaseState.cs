using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
	public AttackState attackState;
	public CharacterController controller;
	public Vector3 target = Vector3.zero;
	public float speed = 30.0f;

	private bool isInRange = false;

	public override State RunCurrentState()
	{
		Vector3 velocity = target - transform.position;
		velocity.Normalize();
		velocity *= speed * Time.deltaTime;
		controller.Move(velocity);

		CheckIsInRange();

		if (isInRange)
		{
			return attackState;
		}
		else
		{
			return this;
		}
	}

	private bool CheckIsInRange()
	{
		isInRange = (Vector3.Distance(transform.position, target) < 2.0f);

		return isInRange;
	}
}
