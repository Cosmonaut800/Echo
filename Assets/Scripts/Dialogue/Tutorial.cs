using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	public bool hasStomped = false;
	public bool hasMoved = false;
	public bool hasRemembered = false;
	public bool hasDug = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void TriggerStomp()
	{
		hasStomped = true;
	}

	public void TriggerMove()
	{
		hasMoved = true;
	}

	public void TriggerRemember()
	{
		hasRemembered = true;
	}

	public void TriggerDig()
	{
		hasDug = true;
	}
}
