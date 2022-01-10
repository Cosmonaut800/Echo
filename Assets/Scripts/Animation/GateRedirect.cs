using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateRedirect : MonoBehaviour
{
	private EchoWaveManager echoManager;
	public Transform leftPivot;
	public Transform rightPivot;
	public AudioSource gateOpen;
	public AudioSource music;

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

	public void PlaySound()
	{
		gateOpen.Play();
	}

	public void PlayMusic()
	{
		music.Play();
	}
}
