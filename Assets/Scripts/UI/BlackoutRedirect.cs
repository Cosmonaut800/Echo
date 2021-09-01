using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutRedirect : MonoBehaviour
{
	public HealthManager healthManager;

	public void Respawn()
	{
		healthManager.Respawn();
	}
}
