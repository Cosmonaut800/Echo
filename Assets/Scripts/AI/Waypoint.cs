using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	public Transform nextTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnDrawGizmos()
	{
		Vector3 ray = nextTarget.position - transform.position;
		ray.Normalize();
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 0.5f);
		Gizmos.DrawRay(transform.position, ray);
	}
}
