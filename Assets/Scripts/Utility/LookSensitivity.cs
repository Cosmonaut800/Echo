using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookSensitivity : MonoBehaviour
{
	[SerializeField] private CinemachineFreeLook cam;
	private float defaultXSpeed = 1.0f;
	private float defaultYSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
		defaultXSpeed = cam.m_XAxis.m_MaxSpeed;
		defaultYSpeed = cam.m_YAxis.m_MaxSpeed;
    }

	public void ChangeHorizontalSpeed(float value)
	{
		cam.m_XAxis.m_MaxSpeed = defaultXSpeed * value;
	}

	public void ChangeVerticalSpeed(float value)
	{
		cam.m_YAxis.m_MaxSpeed = defaultYSpeed * value;
	}
}
