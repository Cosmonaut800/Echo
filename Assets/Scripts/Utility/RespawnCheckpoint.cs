using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheckpoint : MonoBehaviour
{
	public Transform checkpoint;
	public HealthManager healthManager;

	private void OnTriggerEnter(Collider other)
	{
		healthManager.checkpoint = checkpoint;
	}
}
