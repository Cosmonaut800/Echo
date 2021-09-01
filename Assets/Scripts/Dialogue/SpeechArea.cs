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
