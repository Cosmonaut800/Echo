using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisible : MonoBehaviour
{
	public SnakeIdleState follow;

    // Update is called once per frame
    void Update()
    {
		transform.position = follow.targetedPosition.position;
	}
}
