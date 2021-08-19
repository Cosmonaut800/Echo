using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
	public IdleState idleState;
	public EchoWaveManager echoManager;

	private EnemyController enemyController;
	private bool inAnimation = false;

	public void Start()
	{
		enemyController = transform.parent.parent.GetComponent<EnemyController>();
	}
	public override State RunCurrentState()
	{
		inAnimation = enemyController.GetInAttack();
		enemyController.SetGFXPosition(transform.position - (1.9f * Vector3.up));

		if(enemyController.IsInAnimation("Armature_Snake_Emerge"))
		{
			enemyController.TriggerAttack();
		}

		if (enemyController.GetInAttack())
		{
			enemyController.SetIsSearching(false);
			enemyController.SetIsIdle(true);
			idleState.SetDetectPlayer(false);
			idleState.home.position = transform.position + (0.1f * Vector3.forward);
			return idleState;
		}
		else
		{
			return this;
		}
	}
}
