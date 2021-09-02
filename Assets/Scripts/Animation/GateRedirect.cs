using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateRedirect : MonoBehaviour
{
	private EchoWaveManager echoManager;
	public Transform leftPivot;
	public Transform rightPivot;

    // Start is called before the first frame update
    void Start()
    {
		echoManager = FindObjectOfType<EchoWaveManager>();
    }

	public void DoNPCWalk()
	{
		echoManager.DoNPCWalk(leftPivot);
		echoManager.DoNPCWalk(rightPivot);
	}
}
