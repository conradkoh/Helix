using System;
using UnityEngine;
using Helix.Components.Controls.Controllers;
using Helix.Components.Controls.Events;

public class Player : MonoBehaviour
{
    UserInputController controller = UserInputController.GetInstance();

    public Player()
    {

    }

    public void Awake()
    {
		
    }

	public void Start()
	{
		InitPlayer (); //ideally this should be called by subscribing to an event on GameEngine, but im putting it here first to get it out of the way
	}

	public void InitPlayer()
	{
		controller.Fire += Fire;
		controller.Move += Move;
	}

    public void Fire(object sender, FireIntentSpecifiedArgs args)
    {
        Debug.Log("Player Firing!");
    }

    public void Move(object sender, MoveIntentSpecifiedArgs args)
    {
        Debug.Log(String.Format("Player Moving x: {0}, y: {1}", args.direction.x, args.direction.y));
    }
}