using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

	public IPlayerControl controls;
	// Use this for initialization
	void Start ()
	{
		switch (PlayerControlConfig.MODE) {
		case MODES.DESKTOP:
			this.controls = new DesktopPlayerControl ();
			break;
		case MODES.MOBILE:
			this.controls = new MobilePlayerControl ();
			break;
		default:
			break;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		this.controls.Fire ();
	}
}
