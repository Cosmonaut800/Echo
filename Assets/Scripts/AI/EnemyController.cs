using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public Waypoint waypoint;
	public float speed = 5.0f;
	private Transform target;
	private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
		controller = GetComponent<CharacterController>();
		target = waypoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 velocity = target.position - transform.position;
		velocity.Normalize();
		velocity *= speed * Time.deltaTime;

		controller.Move(velocity);

		if(controller.bounds.Contains(waypoint.transform.position))
		{
			target = waypoint.nextTarget;
			waypoint = waypoint.nextTarget.GetComponent<Waypoint>();
		}
    }
}
