using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wind : MonoBehaviour
{
	public EchoWaveManager echoManager;
	public Animator animator;
	public AudioSource windSound;
	public Slider volumeSlider;
	public BoxCollider wind;
	private Collider player;

	private Tutorial tutorial;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
		if (player == null) Debug.Log("Player collider not found.");
		wind = transform.GetComponent<BoxCollider>();
		if (wind == null) Debug.Log("Wind box not found.");

		tutorial = FindObjectOfType<Tutorial>();
	}

	public void SoundFadeIn()
	{
		windSound.volume = 0.0f;
		StopAllCoroutines();
		StartCoroutine(FadeSound(5.0f, volumeSlider.value));
	}

	public void SoundFadeOut()
	{
		windSound.volume = volumeSlider.value;
		StopAllCoroutines();
		StartCoroutine(FadeSound(5.0f, 0.0f));
	}

	IEnumerator FadeSound(float timeToFade, float target)
	{
		float timer = 0.0f;
		float start = windSound.volume;

		while(timer < timeToFade)
		{
			windSound.volume = (target - start) * (timer / timeToFade) + start;

			timer += Time.deltaTime;
			yield return null;
		}

		windSound.volume = target;
	}

	private void OnTriggerEnter(Collider other)
	{
		//echoManager.lifeMultiplier = 0.15f;
		animator.SetBool("InWind", true);
		tutorial.TriggerWind();
	}

	private void OnTriggerExit(Collider other)
	{
		//echoManager.lifeMultiplier = 1.0f;
		animator.SetBool("InWind", false);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		if (wind != null)
		{
			Gizmos.DrawWireCube(transform.position, wind.size);
		}
	}
}
