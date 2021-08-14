using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public IdleState idleState;

	public void Detected(Vector3 callerPosition)
	{
		idleState.chaseState.target = callerPosition;
		idleState.SetDetectPlayer(true);
	}
}
