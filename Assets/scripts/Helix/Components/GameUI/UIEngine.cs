using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEngine : MonoBehaviour {

	//events
	public static event UIEngineEvent ShouldBuildUI;

	//UI Object references
	public GameObject joystick;

	//singleton
	private static UIEngine _instance;

	void Awake()
	{ 
		if(_instance == null)
		{
			_instance = this;
		}

		Main.ShouldInitUI += InitUI;
	}

	public static UIEngine GetInstance()
	{
		return UIEngine._instance;
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void InitUI()
	{
		Debug.Log ("Initializing UI...");
		if (UIEngine.ShouldBuildUI != null) {
			UIEngine.ShouldBuildUI ();
		}
	}

	#region mobile
	public static void BuildMobileControls()
	{
		UIEngine._instance.GetJoystick ().SetActive (true);
	}
	#endregion



	public GameObject GetJoystick(){
		if (this.joystick == null) {
			Debug.Log ("Joystick reference null");
		}

		return this.joystick;
	}

	#region desktop
	public static void BuildDesktopControls()
	{

	}
	#endregion
}
