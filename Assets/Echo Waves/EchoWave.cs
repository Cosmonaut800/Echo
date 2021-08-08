using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoWave// : MonoBehaviour
{
	public Transform source;
	public float maxLife;
	public Color color;

	private float life;
	private float radius;
	private float speed;
	private bool propagating;
	

    // Start is called before the first frame update
    void Start()
    {
		initWave();
    }

	public void initWave()
	{
		radius = 0.0f;
		speed = 1.0f;
		life = 0.0f;
		propagating = false;
	}

	public void expand()
	{
		if (propagating && life < maxLife)
		{
			radius += 20.0f * speed * Time.deltaTime;
			speed = 5.0f;//+= 0.2f;
			life += 1.0f * Time.deltaTime;
		}
		else if(propagating)
		{
			initWave();
		}
	}

	public float remainingLife()
	{
		return maxLife - life;
	}

	public float getRadius()
	{
		return radius;
	}

	public float getSpeed()
	{
		return speed;
	}

	public void setSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

	public float getLife()
	{
		return life;
	}

	public void setLife(float newLife)
	{
		life = newLife;
	}

	public bool getPropagating()
	{
		return propagating;
	}

	public void setPropagating(bool newPropagating)
	{
		propagating = newPropagating;
	}

	public Color getColor()
	{
		return color;
	}
}
