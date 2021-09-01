using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
	public EchoWaveManager echoManager;
	public Animator animator;
	public BoxCollider wind;
	private Collider player;

	private Tutorial tutorial;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
		if (player == null) Debug.Log("Player collider not found.");
		wind = transform.GetComponent<BoxCollider>();
		if (wind == null) Debug.Log("Wind box not found.");

		tutorial = FindObjectOfType<Tutorial>();
	}

	private void OnTriggerEnter(Collider other)
	{
		//echoManager.lifeMultiplier = 0.15f;
		animator.SetBool("InWind", true);
		Debug.Log("Entered wind box.");
		tutorial.TriggerWind();
	}

	private void OnTriggerExit(Collider other)
	{
		//echoManager.lifeMultiplier = 1.0f;
		animator.SetBool("InWind", false);
		Debug.Log("Exited wind box.");
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
