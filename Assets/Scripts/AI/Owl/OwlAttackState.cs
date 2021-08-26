using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlAttackState : State
{
	public OwlRetreatState retreatState;
	public Vector3 target;

	[HideInInspector]
	public bool reachedPlayer = false;

	private bool inRange = false;
	private CharacterController controller;
	private Transform player;
	private Vector3 velocity;

	private void Start()
	{
		controller = transform.parent.parent.GetComponent<CharacterController>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public override State RunCurrentState()
	{
		if (!reachedPlayer)
		{
			velocity = player.position - transform.position;
			velocity.Normalize();
			velocity *= 50.0f * Time.deltaTime;
		}

		controller.Move(velocity);

		if (Vector3.Distance(player.position, transform.position) < 20.0f)
		{
			if(Vector3.Distance(player.position, transform.position) < 10.0f)
			{
				//Attack()
				inRange = true;
			}
			reachedPlayer = true;
		}

		if (inRange)
		{
			retreatState.velocity = velocity;
			retreatState.timer = 0.0f;
			inRange = false;
			return retreatState;
		}
		else
		{
			return this;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, 20.0f);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 10.0f);
	}
}
