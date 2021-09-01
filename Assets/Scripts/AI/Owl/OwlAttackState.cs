using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlAttackState : State
{
	public OwlEnemyController enemyController;
	public OwlRetreatState retreatState;
	public Vector3 target;
	//public CapsuleCollider hurtBox;

	public float outerRange = 20.0f;
	public float middleRange = 10.0f;
	public float innerRange = 5.0f;

	[HideInInspector]
	public bool reachedPlayer = false;

	private bool inRange = false;
	private bool attackTriggered = false;
	private CharacterController controller;
	private Transform player;
	private Vector3 velocity;
	private float timer = 0.0f;
	private Transform graphics;

	private void Start()
	{
		controller = transform.parent.parent.GetComponent<CharacterController>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		graphics = transform.parent.parent.Find("Graphics");
	}

	public override State RunCurrentState()
	{
		//graphics.position = Vector3.MoveTowards(graphics.position, 2.4f * Vector3.back, 0.5f);

		if (!reachedPlayer)
		{
			velocity = player.position - transform.position;
			velocity.Normalize();
			velocity *= 50.0f * Time.deltaTime;
		}
		else
		{
			timer += Time.deltaTime;
			if(timer > 1.0f)
			{
				inRange = true;
			}
		}

		controller.Move(velocity);

		if (Vector3.Distance(player.position, transform.position) < outerRange)
		{
			if (!attackTriggered)
			{
				enemyController.TriggerAttack();
				attackTriggered = true;
			}
			if (Vector3.Distance(player.position, transform.position) < middleRange)
			{
				reachedPlayer = true;
				if (Vector3.Distance(player.position, transform.position) < innerRange)
				{
					inRange = true;
				}
			}
		}

		if (inRange)
		{
			retreatState.velocity = velocity;
			retreatState.timer = 0.0f;
			timer = 0.0f;
			attackTriggered = false;
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
		Gizmos.DrawWireSphere(transform.position, outerRange);
		Gizmos.color = Color.grey;
		Gizmos.DrawWireSphere(transform.position, middleRange);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, innerRange);
	}
}
