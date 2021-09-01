using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechArea : MonoBehaviour
{
	public ThirdPersonMovement player;
	public Animator dialogueAnimator;
	public Dialogue dialogue;

	private DialogueManager manager;
	private bool dialogueStarted = false;
	private EchoWaveManager echoManager;
	private float talkTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
		manager = FindObjectOfType<DialogueManager>();
		echoManager = FindObjectOfType<EchoWaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (!dialogueAnimator.GetBool("IsOpen") && dialogueStarted)
		{
			player.LockMovement(false);
			player.LockStomp(false);
			//dialogueStarted = false;
		}

		if (Input.GetButtonDown("Fire1")) manager.DisplayNextSentence();

		talkTimer += Time.deltaTime;

		if (talkTimer > 5.0f)
		{
			talkTimer = 0.0f;
			echoManager.DoNPCWalk(transform);
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		if (!dialogueStarted)
		{
			player.LockMovement(true);
			player.LockStomp(true);
			dialogueStarted = true;

			manager.StartDialogue(dialogue);
		}
	}
}
