using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;
	public bool canBePaused = true;
	public GameObject ThirdPersonCamera;
	public Canvas canvas;
	public Canvas pauseMenu;
	public Animator OPAnimator;
	public Animator WaresAnimator;
	public Animator BlackoutAnimator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
    }

	public void Resume()
	{
		Time.timeScale = 1.0f;
		isPaused = false;
		ThirdPersonCamera.SetActive(true);
		canvas.gameObject.SetActive(true);
		pauseMenu.gameObject.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		OPAnimator.SetBool("Opened", true);
		WaresAnimator.SetTrigger("Open");
		BlackoutAnimator.SetTrigger("Pause");
	}

	private void Pause()
	{
		if (canBePaused)
		{
			Time.timeScale = 0.0f;
			isPaused = true;
			ThirdPersonCamera.SetActive(false);
			canvas.gameObject.SetActive(false);
			pauseMenu.gameObject.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
