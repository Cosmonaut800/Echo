using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisible : MonoBehaviour
{
	public IdleState follow;

    // Update is called once per frame
    void Update()
    {
		transform.position = follow.targetedPosition.position;
	}
}
