using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoWaveManager : MonoBehaviour
{
	public Transform caller;
	public Transform[] responders;
	public Material[] echoMaterials;

	private EchoWave[] echoWaves = new EchoWave[32];
	private Vector4[] waveSource = new Vector4[32];
	private float[] waveRadius = new float[32];
	private float[] waveLife = new float[32];

	private float engine = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
		for(int i=0; i<echoWaves.Length; i++)
		{
			echoWaves[i] = new EchoWave();
			echoWaves[i].initWave();
			echoWaves[i].source = caller;
		}

		/*echoWaves[1].initWave();
		echoWaves[1].source = responders[0];
		echoWaves[2].initWave();
		echoWaves[2].source = responders[1];
		echoWaves[3].initWave();
		echoWaves[3].source = responders[2];*/
	}

    // Update is called once per frame
    void Update()
	{
		/* The terrain needs a property visible by the inspector to be updated in the script
		   in order for any other property updates to be visible. (??????) */
		echoMaterials[0].SetFloat("_Engine", engine);
		engine += 0.1f;
		if (engine > 1.0f) engine = -engine;

		UpdateArray();
		echoMaterials[0].SetInt("_WaveCount", 4);
		echoMaterials[0].SetVectorArray("_WaveOrigin", waveSource);

		echoWaves[0].expand();
		echoWaves[1].expand();
		echoWaves[2].expand();
		echoWaves[3].expand();

		if (Input.GetButtonDown("Fire1"))
		{
			echoWaves[0].maxLife = 2.0f;
			echoWaves[0].setPropagating(true);
		}

		for (int i=0; i<responders.Length; i++)
		{
			if(Vector3.Distance(responders[i].position, echoWaves[0].source.position) < echoWaves[0].getRadius() && !echoWaves[i+1].getPropagating())
			{
				echoWaves[i+1].maxLife = 2.0f;
				echoWaves[i+1].setLife(echoWaves[0].getLife());
				echoWaves[i+1].source = responders[i];
				echoWaves[i+1].setSpeed(echoWaves[0].getSpeed());
				echoWaves[i+1].setPropagating(true);
			}
		}
		
		UpdateArray();
		Draw();
	}

	private void Draw()
	{
		echoMaterials[0].SetFloatArray("_WaveRadius", waveRadius);
		echoMaterials[0].SetFloatArray("_WaveLife", waveLife);
	}

	private void UpdateArray()
	{
		for(int i=0; i<echoWaves.Length; i++)
		{
			Debug.Log(i);
			waveSource[i] = echoWaves[i].source.position;
			waveRadius[i] = echoWaves[i].getRadius();
			waveLife[i] = echoWaves[i].remainingLife()/echoWaves[i].maxLife;
		}
	}
}
