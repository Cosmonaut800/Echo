using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRedirect : MonoBehaviour
{
	public EchoWaveManager echoWaveManager;

    public void DoStomp()
	{
		echoWaveManager.DoStomp();
	}

	public void DoWalk()
	{
		echoWaveManager.DoWalk();
	}
}
