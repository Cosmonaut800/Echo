using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HealthManager : MonoBehaviour
{
	public float maxHealth;
	public Transform checkpoint;
	public Animator blackoutAnimator;
	public PostProcessProfile ppProfile;
	private float timer = 0.0f;
	private CharacterController controller;
	private bool fadeTriggered = false;
	private Vignette vignette;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
		vignette = ppProfile.GetSetting<Vignette>();
	}

	// Update is called once per frame
	void LateUpdate()
    {
		timer -= Time.deltaTime;
		if (timer < 0.0f) timer = 0.0f;
		if (timer > maxHealth && !fadeTriggered)
		{
			timer = maxHealth;
			fadeTriggered = true;
			blackoutAnimator.SetTrigger("Fade");
		}

		vignette.opacity.Override(timer / maxHealth);
	}

	public void DealDamage(float damage)
	{
		timer += damage;
	}

	public void Respawn()
	{
		fadeTriggered = false;
		timer = 0.0f;
		controller.Move(checkpoint.position - transform.position);
		controller.SimpleMove(Vector3.zero);
		transform.position = checkpoint.position;
	}
}
