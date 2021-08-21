using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlRetreatState : State
{
	public OwlIdleState idleState;

	public override State RunCurrentState()
	{
		return this;
	}
}
