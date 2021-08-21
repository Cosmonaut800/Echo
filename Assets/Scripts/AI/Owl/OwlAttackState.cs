using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlAttackState : State
{
	public OwlRetreatState retreatState;
	public Vector3 target;

	private CharacterController controller;

	private void Start()
	{
		controller = transform.parent.parent.GetComponent<CharacterController>();
	}

	public override State RunCurrentState()
	{
		Vector3 velocity = target - transform.position;
		velocity.Normalize();
		velocity *= 20.0f * Time.deltaTime;

		controller.Move(velocity);

		return this;
	}
}
