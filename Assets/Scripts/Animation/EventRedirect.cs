using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRedirect : MonoBehaviour
{
	//public AudioManager audioManager;
	public AudioSource stomp;
	public AudioSource step1;
	public AudioSource step2;
	public AudioSource step3;
	public AudioSource dig;
	public EchoWaveManager echoWaveManager;
	public Pickup pickup;

    public void DoStomp()
	{
		//audioManager.Play("stomp");
		echoWaveManager.DoStomp();
	}

	public void DoWalk()
	{
		int sound = Random.Range(1, 4);

		if(sound <=1)
		{
			//audioManager.Play("sandstep1");
			step1.Play();
		}
		else if(sound == 2)
		{
			//audioManager.Play("sandstep2");
			step2.Play();
		}
		else
		{
			//audioManager.Play("sandstep3");
			step3.Play();
		}
		
		echoWaveManager.DoWalk();
	}

	public void IncrementItems()
	{
		pickup.Increment();
	}

	public void DecrementItems()
	{
		pickup.Decrement();
	}

	public void PlayStomp()
	{
		stomp.Play();
	}

	public void PlayDig()
	{
		dig.Play();
	}
}
