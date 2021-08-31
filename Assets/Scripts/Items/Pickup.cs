using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pickup : MonoBehaviour
{
	public TextMeshProUGUI displayText;

	[SerializeField]
	private int itemCount = 3;

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

	public void Decrement()
	{
		itemCount--;
		if (itemCount < 0) itemCount = 0;
	}

	public void Decrement(int amount)
	{
		itemCount -= amount;
		if (itemCount < 0) itemCount = 0;
	}
}
