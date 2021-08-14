using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
	public Text displayText;

	private int itemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		displayText.text = itemCount.ToString();
	}

	public void Increment()
	{
		itemCount++;
	}
}
