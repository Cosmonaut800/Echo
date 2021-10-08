using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRedirect : MonoBehaviour
{
	public ThirdPersonMovement player;
	public SpeechArea NPC;
    
	public void LockMovement()
	{
		player.LockMovement(true);
	}

	public void UnlockMovement()
	{
		player.LockMovement(false);
	}

	public void LockStomp()
	{
		player.LockStomp(true);
	}

	public void UnlockStomp()
	{
		player.LockStomp(false);
	}

	public void LockBoth()
	{
		player.LockMovement(true);
		player.LockStomp(true);
	}

	public void UnlockBoth()
	{
		player.LockMovement(false);
		player.LockStomp(false);
	}

	public void LockNPC()
	{
		NPC.dialogueStarted = false;
	}
}
