using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlEnemyRedirect : MonoBehaviour
{
	public OwlEnemyController enemyController;
	public ThirdPersonMovement playerController;
	public HealthManager healthManager;
	public Pickup pickup;
	public AudioSource flap;
	public AudioSource attackSound;
	public CapsuleCollider hurtBox;

    public void PlayFlap()
	{
		flap.Play();
	}

	public void PlayAttack()
	{
		attackSound.Play();
	}

	public void DoEnemyStomp()
	{
		enemyController.DoEnemyStomp();
	}

	public void DecrementItems()
	{
		pickup.Decrement();
	}

	public void DoDamage()
	{
		healthManager.DealDamage(6.0f);
		//playerController.DoDamage(transform.position, 7.0f);
	}
}
