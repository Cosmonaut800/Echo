using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
	public Animator firstAnimator;
	public Animator secondAnimator;

	[HideInInspector]
	public List<Vector3> waypoints;

	public Transform first;
	public Transform second;

	private int pointCount = 0;
	private Tutorial tutorial;

    // Start is called before the first frame update
    void Start()
    {
		//first = transform.Find("First");
		//second = transform.Find("Second");
		waypoints.Add(Vector3.zero);
		waypoints.Add(Vector3.zero);
		tutorial = FindObjectOfType<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 firstDir;
		Vector3 secondDir;

		firstDir = waypoints[1] - transform.position;
		firstDir.y = 0.0f;
		secondDir = waypoints[0] - transform.position;
		secondDir.y = 0.0f;

		first.rotation = Quaternion.LookRotation(firstDir, Vector3.up);
		second.rotation = Quaternion.LookRotation(secondDir, Vector3.up);
	}

	public void AddWaypoint(Vector3 waypoint)
	{
		waypoints.Add(waypoint);
		waypoints.RemoveAt(0);
		pointCount++;
		ShowArrows();
		tutorial.TriggerRemember();
	}

	public void ShowArrows()
	{
		if (pointCount > 1)
		{
			firstAnimator.SetTrigger("FirstIn");
			secondAnimator.SetTrigger("SecondIn");
		}
		else if (pointCount == 1)
		{
			firstAnimator.SetTrigger("FirstIn");
		}
	}
}
