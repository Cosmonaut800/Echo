using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlIdleState : State
{
	public OwlAttackState attackState;

	private bool detectPlayer = false;

	public override State RunCurrentState()
	{

		if(detectPlayer)
		{
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
