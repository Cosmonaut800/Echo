using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncoupleRotation : MonoBehaviour
{
	public Transform parent;
	public Transform child;

    // Update is called once per frame
    void Update()
    {
		child.transform.rotation = Quaternion.identity;
    }
}
