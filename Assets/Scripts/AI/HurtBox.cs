using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
	public ThirdPersonMovement player;
	public HealthManager healthManager;
	public float range = 100.0f;

	private void OnTriggerEnter(Collider other)
	{
		healthManager.DealDamage(6.0f);
		player.DoDamage(transform.position, range);
	}
}
