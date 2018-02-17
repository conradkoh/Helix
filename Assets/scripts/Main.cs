using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

	public IPlayerControl controls;
	public PlayerControlsController playerControlsController;
	// Use this for initialization
	void Start ()
	{
		this.controls = PlayerControlFactory.GetControls ();
		this.playerControlsController = PlayerControlsController.GetInstance ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.playerControlsController.CheckPlayerFiring (this.controls);
	}
}
