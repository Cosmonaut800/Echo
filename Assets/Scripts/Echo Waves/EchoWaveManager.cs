using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoWaveManager : MonoBehaviour
{
	public Transform caller;
	public Transform[] responders;
	public ThirdPersonMovement movementController;
	public Material[] echoMaterials;

	private List<EchoWave> echoWaves = new List<EchoWave>();
	private List<int> callerWaveIndex = new List<int>();
	private List<int> responderWaveIndex = new List<int>();
	private List<List<int>> callerWaveChild = new List<List<int>>();

	private Vector4[] waveSource = new Vector4[32];
	private float[] waveRadius = new float[32];
	private float[] waveLife = new float[32];
	private Color[] waveColor = new Color[32];

	private float engine = 0.0f;

    void Start()
    {
		for(int i=0; i<32; i++)
		{
			waveSource[i] = new Vector4();
			waveColor[i] = new Color();
		}
	}

    void Update()
	{
		/* The terrain needs a property visible by the inspector to be updated in the script
		   in order for any other property updates to be visible. (??????) */
		echoMaterials[0].SetFloat("_Engine", engine);
		engine += 0.1f;
		if (engine > 1.0f) engine = -engine;

		UpdateArray();

		for (int i = 0; i < echoMaterials.Length; i++)
		{
			echoMaterials[i].SetInt("_WaveCount", echoWaves.Count);
			if (echoWaves.Count > 0) echoMaterials[i].SetVectorArray("_WaveOrigin", waveSource);
		}

		for(int i=0; i<echoWaves.Count; i++)
		{
			echoWaves[i].expand();
		}

		for (int i=0; i<responders.Length; i++)
		{
			for (int j = 0; j < callerWaveIndex.Count; j++)
			{
				if (Vector3.Distance(responders[i].position, echoWaves[callerWaveIndex[j]].source.position) < echoWaves[callerWaveIndex[j]].getRadius() && !callerWaveChild[j].Exists(x => x==i))
				{
					Color color = new Color(0.5f, 1.0f, 1.0f, 1.0f);

					if (responders[i].CompareTag("Enemy"))
					{
						color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
					}

					CreateWave(echoWaves[callerWaveIndex[j]].maxLife, echoWaves[callerWaveIndex[j]].getSpeed());
					responderWaveIndex.Add(echoWaves.Count - 1);
					callerWaveChild[j].Add(i);
					echoWaves[echoWaves.Count - 1].setLife(echoWaves[callerWaveIndex[j]].getLife());
					echoWaves[echoWaves.Count - 1].source = responders[i];
					echoWaves[echoWaves.Count - 1].color = color;
					echoWaves[echoWaves.Count - 1].setPropagating(true);
				}
			}
		}

		if (callerWaveIndex.Count + responderWaveIndex.Count != echoWaves.Count) Debug.Log("*!*!*!*!* Callers and responders do not match total number of waves! *!*!*!*!*");

		UpdateArray();
		if (echoWaves.Count > 0) Draw();

		for(int i=0; i<echoWaves.Count; i++)
		{
			if(!echoWaves[i].getPropagating())
			{
				DestroyWave(i);
			}
		}
	}

	private void CreateWave(float maxLife, float speed)
	{
		echoWaves.Add(new EchoWave());
		if (echoWaves.Count > 32)
		{
			Debug.Log("Max wave count exceeded: " + echoWaves.Count);
			DestroyWave(0);
			Debug.Log("New wave count: " + echoWaves.Count);
		}
		echoWaves[echoWaves.Count - 1].maxLife = maxLife;
		echoWaves[echoWaves.Count - 1].setLife(0.0f);
		echoWaves[echoWaves.Count - 1].setSpeed(speed);
		echoWaves[echoWaves.Count - 1].source = caller;
		echoWaves[echoWaves.Count - 1].color = new Color(0.5f, 0.5f, 1.0f, 1.0f);
	}

	private void DestroyWave(int index)
	{
		echoWaves.RemoveAt(index);

		if(callerWaveIndex.Exists(x => x == index)) callerWaveChild.RemoveAt(callerWaveIndex.IndexOf(index));

		callerWaveIndex.RemoveAll(x => x == index);
		responderWaveIndex.RemoveAll(x => x == index);
		for (int i = 0; i < callerWaveIndex.Count; i++)
		{
			if (callerWaveIndex[i] > index)
			{
				callerWaveIndex[i]--;
			}
		}
		for (int i = 0; i < responderWaveIndex.Count; i++)
		{
			if (responderWaveIndex[i] > index)
			{
				responderWaveIndex[i]--;
			}
		}
	}

	private void Draw()
	{
		echoMaterials[0].SetFloatArray("_WaveRadius", waveRadius);
		echoMaterials[0].SetFloatArray("_WaveLife", waveLife);
		echoMaterials[0].SetColorArray("_WaveColor", waveColor);
		
		for (int j = 0; j < responderWaveIndex.Count; j++) waveLife[responderWaveIndex[j]] = 0.0f;
		
		for (int i = 1; i < echoMaterials.Length; i++)
		{
			echoMaterials[i].SetFloatArray("_WaveRadius", waveRadius);
			echoMaterials[i].SetFloatArray("_WaveLife", waveLife);
			echoMaterials[i].SetColorArray("_WaveColor", waveColor);
		}
	}

	private void UpdateArray()
	{
		for(int i=0; i<echoWaves.Count; i++)
		{
			waveSource[i] = echoWaves[i].source.position;
			waveRadius[i] = echoWaves[i].getRadius();
			waveLife[i] = echoWaves[i].remainingLife()/echoWaves[i].maxLife;
			waveColor[i] = echoWaves[i].color;
		}
	}

	public void DoWalk()
	{
		CreateWave(0.75f, 1.0f);
		callerWaveIndex.Add(echoWaves.Count - 1);
		callerWaveChild.Add(new List<int>());
		echoWaves[echoWaves.Count - 1].color = new Color(0.25f, 0.25f, 0.5f, 1.0f);
		echoWaves[echoWaves.Count - 1].setPropagating(true);
	}

	public void DoStomp()
	{
		CreateWave(2.0f, 5.0f);
		callerWaveIndex.Add(echoWaves.Count - 1);
		callerWaveChild.Add(new List<int>());
		echoWaves[echoWaves.Count - 1].setPropagating(true);
	}
}
