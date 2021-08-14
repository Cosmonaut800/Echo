using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	private Transform player;

	private Pickup pickup;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindWithTag("Player").transform;
		pickup = player.GetComponent<Pickup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < 5.0f && Input.GetButtonDown("Fire2"))
		{
			pickup.Increment();
			transform.gameObject.SetActive(false);
		}
    }
}
