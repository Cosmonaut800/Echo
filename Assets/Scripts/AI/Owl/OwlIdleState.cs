using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlIdleState : State
{
	public OwlAttackState attackState;
	public Transform home;

	private bool detectPlayer = false;

	public override State RunCurrentState()
	{

		if(detectPlayer)
		{
			attackState.reachedPlayer = false;
			detectPlayer = false;
			return attackState;
		}
		else
		{
			return this;
		}
	}

	public void SetDetectPlayer(bool newDetectPlayer)
	{
		detectPlayer = newDetectPlayer;
	}
}
