using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnemyController : EnemyController
{
	public SnakeIdleState idleState;
	public Animator animator;
	public EchoWaveManager echoManager;
	public float turnSmoothTime = 0.1f;

	private Transform graphics;
	private Transform player;
	private CharacterController controller;
	private Vector3 direction;
	private float turnSmoothVelocity;

	private bool isIdle = true;
	private bool isChasing = false;
	private bool isSearching = false;
	private bool isMoving = false;
	private bool inAttack = false;

	public void Start()
	{
		graphics = transform.Find("Graphics");
		player = GameObject.FindWithTag("Player").transform;
		controller = GetComponent<CharacterController>();
	}

	public void Update()
	{
		inAttack = false;
		direction = player.position - transform.position;
		direction.Normalize();
		float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		float angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
		transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

		animator.SetBool("isIdle", isIdle);
		animator.SetBool("isChasing", isChasing);
		animator.SetBool("isSearching", isSearching);
		animator.SetBool("isMoving", isMoving);

		controller.Move(-5.0f * Vector3.up);
	}
	public override void Detected(Vector3 callerPosition)
	{
		idleState.chaseState.target = callerPosition;
		idleState.SetDetectPlayer(true);
	}

	public void SetDirection(Vector3 newDirection)
	{
		direction = newDirection;
	}

	public void SetGFXPosition(Vector3 newPosition)
	{
		graphics.position = newPosition;
	}

	public void SetIsIdle(bool newIsIdle)
	{
		isIdle = newIsIdle;
	}

	public void SetIsChasing(bool newIsChasing)
	{
		isChasing = newIsChasing;
	}

	public void SetIsSearching(bool newIsSearching)
	{
		isSearching = newIsSearching;
	}

	public void SetisMoving(bool newIsMoving)
	{
		isMoving = newIsMoving;
	}

	public void TriggerAttack()
	{
		animator.SetTrigger("attack");
	}

	public void AttackEnded()
	{
		inAttack = true;
	}

	public bool GetInAttack()
	{
		return inAttack;
	}

	public void DoEnemyStomp()
	{
		echoManager.DoEnemyStomp(transform);
	}

	public void DoEnemyWalk()
	{
		echoManager.DoEnemyWalk(transform);
	}

	public bool IsInAnimation(string name)
	{
		return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
	}
}
