using System;
using UnityEngine;

public class MobilePlayerControl:IPlayerControl
{
	public MobilePlayerControl ()
	{
	}

	public override bool ShouldPlayerFire ()
	{
		return true;
	}

	public override void ShouldPlayerMove ()
	{

	}
}