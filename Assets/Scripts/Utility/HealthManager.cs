using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	public float maxHealth;
	public Transform checkpoint;
	public Animator blackoutAnimator;

	private float timer = 0.0f;
	private CharacterController controller;
	private bool fadeTriggered = false;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void LateUpdate()
    {
		timer -= Time.deltaTime;
		if (timer < 0.0f) timer = 0.0f;
		if (timer > maxHealth && !fadeTriggered)
		{
			fadeTriggered = true;
			blackoutAnimator.SetTrigger("Fade");
		}
	}

	public void DealDamage(float damage)
	{
		timer += damage;
	}

	public void Respawn()
	{
		fadeTriggered = false;
		timer = 0.0f;
		controller.Move(checkpoint.position - transform.position);
		//transform.position = checkpoint.position;
	}
}
