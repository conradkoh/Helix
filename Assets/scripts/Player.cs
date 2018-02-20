using System;
using UnityEngine;
using Helix.Components.Controls.Controllers;
using Helix.Components.Controls.Events;
using Helix.Components.Operator;

public class Player : MonoBehaviour
{
	UserInputController controller = UserInputController.GetInstance ();
	public float health = 0;
	private Operator _operator;

	public Player ()
	{
	}

	public void Awake ()
	{
		this._operator = new Operator (this.health);
	}

	public void Start ()
	{
		InitPlayer (); //ideally this should be called by subscribing to an event on GameEngine, but im putting it here first to get it out of the way
	}

	public void InitPlayer ()
	{
		controller.Fire += Fire;
		controller.Move += Move;
		controller.Face += Face;
	}

	public void Fire (object sender, FireIntentSpecifiedArgs args)
	{
		Debug.Log ("Player Firing!");
		Debug.Log (this._operator.GetSummary ());
	}

	public void Move (object sender, MoveIntentSpecifiedArgs args)
	{
		Debug.Log (String.Format ("Player Moving x: {0}, y: {1}", args.direction.x, args.direction.y));
	}

	public void Face (object sender, FaceIntentSpecifiedArgs args)
	{
		Debug.Log (String.Format ("Player Facing x: {0}", args.direction));
	}
}