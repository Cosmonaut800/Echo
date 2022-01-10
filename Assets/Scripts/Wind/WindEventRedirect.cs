using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEventRedirect : MonoBehaviour
{
	public float lifeMultiplier = 1.0f;
	public EchoWaveManager echoManager;
	public Wind wind;

    // Update is called once per frame
    void Update()
    {
		echoManager.lifeMultiplier = lifeMultiplier;
    }

	public void SoundFadeIn()
	{
		wind.SoundFadeIn();
	}

	public void SoundFadeOut()
	{
		wind.SoundFadeOut();
	}
}
