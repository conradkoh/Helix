using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Controllers;

public class Main : MonoBehaviour
{
    private User _user;

	//Events
	public static event MainEvent ShouldInitControls;
	public static event MainEvent ShouldInitUI;

	// Use this for initialization
	void Start ()
	{
        this._user = gameObject.AddComponent<User>(); //Instantiate the user

		//INITIALIZE CONTROLS
		if (Main.ShouldInitControls != null) {
			Main.ShouldInitControls ();
		}

		//INITIALIZE UI
		if (Main.ShouldInitUI != null) {
			Main.ShouldInitUI ();
		}


	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
