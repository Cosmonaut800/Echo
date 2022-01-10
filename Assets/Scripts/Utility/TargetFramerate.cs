using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFramerate : MonoBehaviour
{
	// Start is called before the first frame update
	public int target = 60;
	public GameObject confirmQuitText;
	public bool ended = false;

	private bool confirm = false;
	private float timer = 0.0f;

	void Awake()
	{
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = target;
	}

	// Update is called once per frame
	void Update()
    {
		if (Application.targetFrameRate != target) Application.targetFrameRate = target;

		if(Input.GetKeyUp(KeyCode.Escape) && ended)
		{
			if (confirm)
			{
				Application.Quit();
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
		Application.Quit();
	}
}
