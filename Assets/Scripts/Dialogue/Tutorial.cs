using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	public bool hasStomped = false;
	public bool hasMoved = false;
	public bool hasRemembered = false;
	public bool hasDug = false;
	public bool hasWinded = false;

	public Animator tutorial;
	public Animator spotlight;
	public Animator title;
	public Animator wares;

	private int stompCount = 0;
	private int digCount = 0;
	private int memoryCount = 0;
	private int windCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (stompCount ==1)
		{
			tutorial.SetTrigger("Move");
			stompCount++;
		}
		else if (stompCount == 3)
		{
			tutorial.SetTrigger("Echo");
			stompCount++;
		}
		
		if (digCount == 1)
		{
			tutorial.SetTrigger("Dig");
			digCount++;
		}

		if (memoryCount == 1)
		{
			tutorial.SetTrigger("Memory");
			memoryCount++;
		}

		if(windCount == 1)
		{
			tutorial.SetTrigger("Wind");
			windCount++;
		}
    }

	public void TriggerStomp()
	{
		hasStomped = true;
		spotlight.SetTrigger("Open");
		title.SetTrigger("Stomp");
		wares.SetTrigger("Open");
		stompCount++;
	}

	public void TriggerMove()
	{
		hasMoved = true;
	}

	public void TriggerRemember()
	{
		hasRemembered = true;
		memoryCount++;
	}

	public void TriggerDig()
	{
		hasDug = true;
		digCount++;
	}

	public void TriggerWind()
	{
		hasWinded = true;
		windCount++;
	}
}
