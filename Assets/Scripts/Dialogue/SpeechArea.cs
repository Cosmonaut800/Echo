using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechArea : MonoBehaviour
{
	public ThirdPersonMovement player;
	public Animator dialogueAnimator;
	public Dialogue dialogue;

	private DialogueManager manager;

    // Start is called before the first frame update
    void Start()
    {
		manager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("IsOpen: " + dialogueAnimator.GetBool("IsOpen"));
		if (!dialogueAnimator.GetBool("IsOpen"))
		{
			player.LockMovement(false);
			player.LockStomp(false);
		}

		if (Input.GetButtonDown("Fire1")) manager.DisplayNextSentence();
    }

	private void OnTriggerEnter(Collider other)
	{
		player.LockMovement(true);
		player.LockStomp(true);

		manager.StartDialogue(dialogue);
	}
}
