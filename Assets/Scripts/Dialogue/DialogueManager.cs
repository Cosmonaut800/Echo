using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public TextMeshProUGUI dialogueText;
	public Animator animator;

	private Queue<string> sentences;

	[HideInInspector]
	public bool dialogueEnded = false;

    // Start is called before the first frame update
    void Start()
    {
		sentences = new Queue<string>();
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.B)) DisplayNextSentence();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		dialogueEnded = false;
		animator.SetBool("IsOpen", true);
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;
	}

	public void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		dialogueEnded = true;
	}
}
