using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlEnemyController : EnemyController
{
	public OwlIdleState idleState;
	public Animator animator;
	public EchoWaveManager echoManager;
	public Transform player;
	public Material eyeMaterial;

	private Vector3 prevPos = Vector3.zero;
	private Vector3 velocity;

	private void Update()
	{
		velocity = transform.position - prevPos;
		prevPos = transform.position;
		float closingDistance = Vector3.Distance(player.position, transform.position);

		if (velocity.magnitude < 0.01f)
		{
			velocity = player.position - transform.position;
			velocity.y = 0.0f;
		}

		if (closingDistance < 100.0f)
		{
			Color eyeColor = new Color(1.0f, 0.66f, 0.0f, 1.0f);
			eyeMaterial.SetColor("_EmissionColor", Color.Lerp(Color.black, eyeColor, 1 - closingDistance/100.0f));
		}	

		velocity.Normalize();
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(velocity), 5.0f);
	}
	public override void Detected(Vector3 callerPosition)
	{
		idleState.attackState.target = callerPosition;
		idleState.SetDetectPlayer(true);
	}

	public void SetIsFlying(bool value)
	{
		animator.SetBool("IsFlying", value);
	}

	public void DoEnemyStomp()
	{
		echoManager.DoEnemyStomp(transform);
	}

	public void TriggerAttack()
	{
		Debug.Log("Triggered attack.");
		animator.SetTrigger("Attack");
	}

	public void DoDamage()
	{

	}
}
