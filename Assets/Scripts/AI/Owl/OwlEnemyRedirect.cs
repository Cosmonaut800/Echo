using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlEnemyRedirect : MonoBehaviour
{
	public OwlEnemyController enemyController;
	public ThirdPersonMovement playerController;
	public HealthManager healthManager;
	public Pickup pickup;
	public AudioSource attackSound;
	public AudioSource flap1;
	public AudioSource flap2;
	public AudioSource flap3;

    public void PlayFlap()
	{
		int sound = Random.Range(1, 4);

		if (sound <= 1)
		{
			//audioManager.Play("sandstep1");
			flap1.Play();
		}
		else if (sound == 2)
		{
			//audioManager.Play("sandstep2");
			flap2.Play();
		}
		else
		{
			//audioManager.Play("sandstep3");
			flap3.Play();
		}
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
