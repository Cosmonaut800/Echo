using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechArea : MonoBehaviour
{
	public ThirdPersonMovement player;
	public Animator dialogueAnimator;
	public Dialogue dialogue;
	public Animator specialAnimator;

	private DialogueManager manager;
	private bool dialogueStarted = false;
	private EchoWaveManager echoManager;
	private float talkTimer = 0.0f;
	private int spokenCount = 0;

    // Start is called before the first frame update
    void Start()
    {
		manager = FindObjectOfType<DialogueManager>();
		echoManager = FindObjectOfType<EchoWaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (spokenCount == 1 && manager.dialogueEnded)
		{
			specialAnimator.SetTrigger("DialogueEnd");
			spokenCount++;
		}

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
		spokenCount++;

		if (!dialogueStarted)
		{
			player.LockMovement(true);
			player.LockStomp(true);
			dialogueStarted = true;

			manager.StartDialogue(dialogue);
		}
	}
}
