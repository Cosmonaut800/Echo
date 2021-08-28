using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEventRedirect : MonoBehaviour
{
	public float lifeMultiplier = 1.0f;
	public EchoWaveManager echoManager;

    // Update is called once per frame
    void Update()
    {
		echoManager.lifeMultiplier = lifeMultiplier;
    }
}
