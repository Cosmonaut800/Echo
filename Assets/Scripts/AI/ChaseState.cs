using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
	public AttackState attackState;
	public CharacterController controller;
	public Vector3 target = Vector3.zero;
	public float speed = 60.0f;

	private bool isInRange = false;
	private EnemyController enemyController;
	private float walkTimer = 0.0f;

	public void Start()
	{
		enemyController = transform.parent.parent.GetComponent<EnemyController>();
	}
	public override State RunCurrentState()
	{
		Vector3 velocity = target - transform.position;
		velocity.Normalize();
		enemyController.SetDirection(velocity);
		velocity *= speed * Time.deltaTime;
		controller.Move(velocity);

		walkTimer += Time.deltaTime;
		if(walkTimer > 0.5f)
		{
			enemyController.DoEnemyWalk();
			walkTimer = 0.0f;
		}

		enemyController.SetGFXPosition(transform.position - (64.0f * Vector3.up));
		CheckIsInRange();

		if (isInRange)
		{
			enemyController.SetIsSearching(true);
			enemyController.TriggerAttack();
			return attackState;
		}
		else
		{
			return this;
		}
	}

	private bool CheckIsInRange()
	{
		isInRange = (Vector3.Distance(transform.position, target) < 6.0f);

		return isInRange;
	}
}
