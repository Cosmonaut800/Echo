using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnemyRedirect : MonoBehaviour
{
	public SnakeEnemyController enemyController;
	public ThirdPersonMovement playerController;
	public Pickup pickup;
	public AudioSource attackSound;

	public void AttackEnded()
	{
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
		Debug.Log("DoDamage()");
		playerController.DoDamage(transform.position);
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
