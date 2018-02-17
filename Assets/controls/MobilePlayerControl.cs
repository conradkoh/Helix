using System;
using UnityEngine;

public class MobilePlayerControl:IPlayerControl
{
	public MobilePlayerControl ()
	{
	}

	public override void Fire ()
	{
		Debug.Log ("Mobile Firing!");
	}

	public override void Move ()
	{

	}
}