using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	PlayerControlsController controller = PlayerControlsController.GetInstance ();

	public void Awake ()
	{
		controller.Fire += Fire;
	}

	public Player ()
	{
		
	}

	public void Fire (object sender, PlayerFiredArgs args)
	{
		Debug.Log ("Player Firing!");
	}
}