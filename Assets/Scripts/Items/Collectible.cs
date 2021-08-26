using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	private Transform player;
	private Pickup pickup;
	private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindWithTag("Player").transform;
		pickup = player.GetComponent<Pickup>();
		animator = player.Find("Graphics").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < 3.0f && Input.GetButtonDown("Fire2"))
		{
			animator.SetTrigger("loot");
			transform.gameObject.SetActive(false);
		}
    }

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, 3.0f);
	}
}
