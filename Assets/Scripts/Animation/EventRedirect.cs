using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRedirect : MonoBehaviour
{
	public EchoWaveManager echoWaveManager;
	public Pickup pickup;

    public void DoStomp()
	{
		echoWaveManager.DoStomp();
	}

	public void DoWalk()
	{
		echoWaveManager.DoWalk();
	}

	public void IncrementItems()
	{
		pickup.Increment();
	}

	public void DecrementItems()
	{
		pickup.Decrement();
	}
}
