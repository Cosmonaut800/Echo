using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public IdleState idleState;

	private CharacterController controller;

	public void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	public void Update()
	{
		controller.Move(-5.0f * Vector3.up);
	}
	public void Detected(Vector3 callerPosition)
	{
		idleState.chaseState.target = callerPosition;
		idleState.SetDetectPlayer(true);
	}
}
