using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaLock : MonoBehaviour
{
	public UIRedirect redirect;
	public GameObject player;
	private bool isLocked = false;

    // Update is called once per frame
    void LateUpdate()
    {
        if (isLocked)
		{
			redirect.LockBoth();
		}
    }

	public void PermanentlyLock()
	{
		//isLocked = true;
		player.SetActive(false);
	}
}
