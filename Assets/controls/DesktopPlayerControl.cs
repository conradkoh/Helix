using System;
using UnityEngine;

public class DesktopPlayerControl: IPlayerControl
{
	public DesktopPlayerControl ()
	{
	}

	public override void Fire ()
	{
		Debug.Log ("Desktop Firing!");
	}

	public override void Move ()
	{
		
	}
}
