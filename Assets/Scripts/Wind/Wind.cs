using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
	private Collider player;
	public BoxCollider wind;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
		if (player == null) Debug.Log("Player collider not found.");
		wind = transform.GetComponent<BoxCollider>();
		if (wind == null) Debug.Log("Wind box not found.");
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Entered wind box.");
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		if (wind != null)
		{
			Gizmos.DrawWireCube(transform.position, wind.size);
		}
	}
}
