using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetFramerate : MonoBehaviour
{
	// Start is called before the first frame update
	public int target = 60;
	public GameObject confirmQuitText;
	public bool ended = false;
	public PauseMenu pause;

	private bool confirm = false;
	private float timer = 0.0f;

	private int[,] resolutions = new int[2, 6] { { 1280, 1600, 1920, 800, 1024, 1280 }, { 720, 900, 1080, 600, 768, 960 } };

	void Awake()
	{
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = target;
	}

	// Update is called once per frame
	void Update()
    {
		if (Application.targetFrameRate != target) Application.targetFrameRate = target;

		if((Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P)) && ended)
		{
			if (confirm)
			{
				QuitGame();
			}
			confirm = true;
		}

		if (!confirm)
		{
			timer = 0.0f;
			confirmQuitText.SetActive(false);
		}
		else
		{
			timer += Time.deltaTime;
			confirmQuitText.SetActive(true);
			if (timer > 5.0f)
			{
				confirm = false;
				confirmQuitText.SetActive(false);
			}
		}
	}

	public void QuitGame()
	{
		pause.Resume();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void SetFullscreen(bool value)
	{
		Screen.fullScreen = value;
	}

	public void ChangeResolution(int option)
	{
		Screen.SetResolution(resolutions[0, option], resolutions[1, option], Screen.fullScreen);
	}
}
