using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttackState : State
{
	public SnakeIdleState idleState;
	public EchoWaveManager echoManager;

	private SnakeEnemyController enemyController;
	private bool inAnimation = false;

	public void Start()
	{
		enemyController = transform.parent.parent.GetComponent<SnakeEnemyController>();
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
			enemyController.inAttack = false;
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
