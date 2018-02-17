using System;
using UnityEngine;

public class DesktopPlayerControl: IPlayerControl
{
	public DesktopPlayerControl ()
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
