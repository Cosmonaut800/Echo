using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
	public IdleState idleState;
	public EchoWaveManager echoManager;

	public override State RunCurrentState()
	{
		echoManager.DoEnemyStomp(transform);

		idleState.SetDetectPlayer(false);
		idleState.home.position = transform.position + (0.1f * Vector3.forward);
		return idleState;
	}
}
