using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	public float maxHealth;
	public Transform checkpoint;

	private float timer = 0.0f;
	private CharacterController controller;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void LateUpdate()
    {
		timer -= Time.deltaTime;
		if (timer < 0.0f) timer = 0.0f;
		if (timer > maxHealth) Respawn();
    }

	public void DealDamage(float damage)
	{
		timer += damage;
	}

	private void Respawn()
	{
		timer = 0.0f;
		controller.Move(checkpoint.position - transform.position);
		//transform.position = checkpoint.position;
	}
}
