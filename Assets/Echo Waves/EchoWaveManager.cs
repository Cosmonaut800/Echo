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
	//private List<List<int>> responderWaveParent = new List<List<int>>();

	private Vector4[] waveSource = new Vector4[32];
	private float[] waveRadius = new float[32];
	private float[] waveLife = new float[32];
	private Color[] waveColor = new Color[32];

	private uint walkTimer;

	private float engine = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
		walkTimer = 0;

		for(int i=0; i<32; i++)
		{
			waveSource[i] = new Vector4();
			waveColor[i] = new Color();
		}

		/*for(int i=0; i<responders.Length; i++)
		{
			responderWaveParent.Add(new List<int>());
		}*/
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
		echoMaterials[0].SetInt("_WaveCount", echoWaves.Count);
		if(echoWaves.Count > 0) echoMaterials[0].SetVectorArray("_WaveOrigin", waveSource);

		for(int i=0; i<echoWaves.Count; i++)
		{
			echoWaves[i].expand();
		}

		/*if (Input.GetButtonDown("Fire1"))
		{
			CreateWave(2.0f, 5.0f);
			callerWaveIndex.Add(echoWaves.Count - 1);
			callerWaveChild.Add(new List<int>());
			echoWaves[echoWaves.Count - 1].setPropagating(true);
		}*/

		for (int i=0; i<responders.Length; i++)
		{
			for (int j = 0; j < callerWaveIndex.Count; j++)
			{
				if (Vector3.Distance(responders[i].position, echoWaves[callerWaveIndex[j]].source.position) < echoWaves[callerWaveIndex[j]].getRadius() && !callerWaveChild[j].Exists(x => x==i))
				{
					CreateWave(echoWaves[callerWaveIndex[j]].maxLife, echoWaves[callerWaveIndex[j]].getSpeed());
					responderWaveIndex.Add(echoWaves.Count - 1);
					callerWaveChild[j].Add(i);
					//responderWaveParent[i].Add(callerWaveIndex[j]);
					echoWaves[echoWaves.Count - 1].setLife(echoWaves[callerWaveIndex[j]].getLife());
					echoWaves[echoWaves.Count - 1].source = responders[i];
					echoWaves[echoWaves.Count - 1].color = new Color(0.5f, 1.0f, 1.0f, 1.0f);
					echoWaves[echoWaves.Count - 1].setPropagating(true);
					Debug.Log("************************");
					Debug.Log("(i, j): "+"("+i+", "+j+")");
					Debug.Log("callerWaveIndex[j]: "+callerWaveIndex[j]);
					//Debug.Log("responderWaveParent[i].Count: "+ responderWaveParent[i].Count);
				}
			}
		}
		Debug.Log("callerWaveIndex.Count: " + callerWaveIndex.Count);
		Debug.Log("responderWaveIndex.Count: " + responderWaveIndex.Count);
		Debug.Log("Current wave count: " + echoWaves.Count.ToString());

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
		/*for (int j = 0; j < responders.Length; j++)
		{
				responderWaveParent[j].RemoveAll(x => x == index);
		}*/
		for (int i = 0; i < callerWaveIndex.Count; i++)
		{
			/*if (callerWaveIndex[i] == index)
			{
				callerWaveIndex.RemoveAt(i);
				i--;
			}
			else*/
			if (callerWaveIndex[i] > index)
			{
				callerWaveIndex[i]--;
			}
		}
		for (int i = 0; i < responderWaveIndex.Count; i++)
		{
			/*if (responderWaveIndex[i] == index)
			{
				responderWaveIndex.RemoveAt(i);
				i--;
			}
			else*/
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
		/*if(movementController.getIsMoving())
		{
			if(walkTimer % 30 == 0)
			{*/
				CreateWave(0.75f, 1.0f);
				callerWaveIndex.Add(echoWaves.Count - 1);
				callerWaveChild.Add(new List<int>());
				echoWaves[echoWaves.Count - 1].setPropagating(true);
			/*}
			walkTimer++;
		}*/
	}

	public void DoStomp()
	{
		CreateWave(2.0f, 5.0f);
		callerWaveIndex.Add(echoWaves.Count - 1);
		callerWaveChild.Add(new List<int>());
		echoWaves[echoWaves.Count - 1].setPropagating(true);
	}
}
