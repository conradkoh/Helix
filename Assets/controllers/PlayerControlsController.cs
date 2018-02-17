using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiredArgs : System.EventArgs
{
	PlayerFiredArgs ()
	{

	}
}

public class PlayerControlsController
{
	private static PlayerControlsController _instance = null;

	public delegate void PlayerFired (object sender, PlayerFiredArgs args);

	public event PlayerFired Fire;

	private PlayerControlsController ()
	{
	}

	public static PlayerControlsController GetInstance ()
	{
		if (PlayerControlsController._instance == null) {
			PlayerControlsController._instance = new PlayerControlsController ();
		}
		return PlayerControlsController._instance;
	}

	public void CheckPlayerFiring (IPlayerControl controls)
	{
		if (controls.ShouldPlayerFire ()) {
			if (this.Fire != null) {
				this.Fire (this, null);	
			}
		}
	}
	
}