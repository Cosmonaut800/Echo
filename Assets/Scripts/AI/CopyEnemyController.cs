/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public EchoWaveManager echoManager;
	public Transform player;
	public Waypoint waypoint;
	public float speed = 5.0f;


	private Transform target;
	private CharacterController controller;

	private int walkFrame = 0;
	private bool detected = false;

    // Start is called before the first frame update
    void Start()
    {
		controller = GetComponent<CharacterController>();
		target = waypoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
		walkFrame++;
		Vector3 velocity = target.position - transform.position;
		velocity.Normalize();
		velocity *= speed * Time.deltaTime;

		controller.Move(velocity);

		if(walkFrame % 30 == 0)
		{
			echoManager.DoEnemyWalk(transform);
		}

		if(controller.bounds.Contains(waypoint.transform.position))
		{
			target = waypoint.nextTarget;
			waypoint = waypoint.nextTarget.GetComponent<Waypoint>();
		}

		if (detected && CollidingWithPlayer())
		{
			Undetect();
		}
    }

	public void Detect(Transform newTarget)
	{
		target = newTarget;
		detected = true;
		speed = 15.0f;
	}

	private void Undetect()
	{
		target = waypoint.nextTarget;
		detected = false;
		speed = 5.0f;
	}

	private bool CollidingWithPlayer()
	{
		return (Vector3.Distance(transform.position, player.position) < 2.0f);
	}
}*/
