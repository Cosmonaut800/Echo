using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlEnemyController : EnemyController
{
	public OwlIdleState idleState;

	public override void Detected(Vector3 callerPosition)
	{
		idleState.attackState.target = callerPosition;
		idleState.SetDetectPlayer(true);
	}
}
