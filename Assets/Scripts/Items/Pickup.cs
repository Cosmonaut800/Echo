using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pickup : MonoBehaviour
{
	public TextMeshProUGUI displayText;
	public Animator gainAnimator;
	public TextMeshProUGUI gainText;
	public Animator loseAnimator;
	public TextMeshProUGUI loseText;
	public TextMeshProUGUI credits;

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
		credits.text = itemCount.ToString();
	}

	public void Increment()
	{
		itemCount++;
		IncreaseAnim(1);
	}

	public void Decrement()
	{
		itemCount--;
		if (itemCount < 0) itemCount = 0;
		else DecreaseAnim(1);
	}

	public void Decrement(int amount)
	{
		itemCount -= amount;
		if (itemCount < 0) itemCount = 0;
		else DecreaseAnim(amount);
	}

	private void IncreaseAnim(int amount)
	{
		gainText.text = "+" + amount.ToString();
		gainAnimator.SetTrigger("Gain");
	}

	private void DecreaseAnim(int amount)
	{
		loseText.text = "-" + amount.ToString();
		loseAnimator.SetTrigger("Lose");
	}
}
