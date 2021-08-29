using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
	public ThirdPersonMovement player;
	public float range = 100.0f;

	private void OnTriggerEnter(Collider other)
	{
		player.DoDamage(transform.position, range);
	}
}
