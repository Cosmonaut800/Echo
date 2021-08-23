using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeIdleState : State
{
	public SnakeChaseState chaseState;
	public CharacterController controller;
	public float speed = 5.0f;
	public Transform home;
	public Transform targetedPosition;

	private bool detectPlayer = false;
	private float walkTimer = 0.0f;
	private bool atHome = false;
	private SnakeEnemyController enemyController;

	public void Start()
	{
		enemyController = transform.parent.parent.GetComponent<SnakeEnemyController>();
	}

	public override State RunCurrentState()
	{
		Vector3 target = home.position;
		Vector3 velocity;

		enemyController.SetGFXPosition(transform.position - (64.0f * Vector3.up));

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
		enemyController.SetDirection(velocity);
		velocity *= speed * Time.deltaTime;

		controller.Move(velocity);

		walkTimer += Time.deltaTime;
		if(walkTimer > 1.0f)
		{
			enemyController.DoEnemyWalk();
			walkTimer = 0.0f;
		}

		if (detectPlayer)
		{
			enemyController.SetIsIdle(false);
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
