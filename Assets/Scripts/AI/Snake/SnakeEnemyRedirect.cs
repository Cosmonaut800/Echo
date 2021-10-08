using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnemyRedirect : MonoBehaviour
{
	public SnakeEnemyController enemyController;
	public ThirdPersonMovement playerController;
	public HealthManager healthManager;
	public Pickup pickup;
	public AudioSource attackSound;

	public void AttackEnded()
	{
		Debug.Log("redirect AttackEnded()");
		enemyController.AttackEnded();
	}

	public void EmergeEnded()
	{
		enemyController.TriggerAttack();
	}

	public void DoEnemyStomp()
	{
		enemyController.DoEnemyStomp();
	}

	public void SetIdle()
	{
		enemyController.SetIsIdle(true);
	}

	public void DoDamage()
	{
		if (playerController.DoDamage(transform.position, 25.0f))
		{
			healthManager.DealDamage(5.0f);
		}
	}

	public void DecrementItems()
	{
		pickup.Decrement();
	}

	public void AttackSound()
	{
		attackSound.Play();
	}
}
