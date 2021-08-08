using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyEchoWave : MonoBehaviour
{
	public Transform source;
	public Transform responder;
	public float maxRadius;
	public Material[] echoMaterials;

	private float radius;
	private float speed;
	private float resRadius;
	private float resSpeed;

    // Start is called before the first frame update
    void Start()
    {
		radius = 0.0f;
		resRadius = 0.0f;
		speed = 1.0f;
		resSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.E))
		{
			radius = 0.0f;
			resRadius = 0.0f;
			speed = 1.0f;
			resSpeed = 1.0f;
			echoMaterials[0].SetFloat("_ResponseRadius", resRadius);
		}
		radius += 20.0f * speed * Time.deltaTime;
		speed += 0.2f;
		echoMaterials[0].SetVector("_WaveOrigin", source.position);
		echoMaterials[0].SetFloat("_WaveRadius", radius);

		if(Vector3.Distance(source.position, responder.position) < radius)
		{
			resRadius += 30.0f * resSpeed * Time.deltaTime;
			resSpeed += 0.1f;
			echoMaterials[0].SetVector("_ResponseOrigin", responder.position);
			echoMaterials[0].SetFloat("_ResponseRadius", resRadius);
		}
    }
}
