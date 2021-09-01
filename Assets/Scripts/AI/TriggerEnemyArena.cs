using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyArena : MonoBehaviour
{
	public Transform[] enableEnemies;
	public Transform[] disableEnemies;

	private void OnTriggerEnter(Collider other)
	{
		for (int i = 0; i < enableEnemies.Length; i++)
		{
			enableEnemies[i].gameObject.SetActive(true);
		}

		for (int i = 0; i < disableEnemies.Length; i++)
		{
			disableEnemies[i].gameObject.SetActive(false);
		}
	}
}
