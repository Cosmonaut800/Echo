using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheckpoint : MonoBehaviour
{
	public Transform checkpoint;
	public HealthManager healthManager;

	private Compass compass;

	private void Start()
	{
		compass = FindObjectOfType<Compass>();
	}

	private void OnTriggerEnter(Collider other)
	{
		healthManager.checkpoint = checkpoint;
		if (Vector3.Distance(compass.waypoints[compass.waypoints.Count - 1], transform.position) > 0.01f)
		{
			compass.AddWaypoint(transform.position);
		}
	}
}
