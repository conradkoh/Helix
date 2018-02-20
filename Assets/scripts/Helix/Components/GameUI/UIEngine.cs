using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEngine : MonoBehaviour
{

	//events
	public static event UIEngineEvent ShouldBuildUI;

	//UI Object references
	public GameObject moveJoystick;
	public GameObject faceJoystick;

	//singleton
	private static UIEngine _instance;

	void Awake ()
	{ 
		if (_instance == null) {
			_instance = this;
		}

		Main.ShouldInitUI += InitUI;
	}

	public static UIEngine GetInstance ()
	{
		return UIEngine._instance;
	}

	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void InitUI ()
	{
		Debug.Log ("Initializing UI...");
		if (UIEngine.ShouldBuildUI != null) {
			UIEngine.ShouldBuildUI ();
		}
	}

	#region mobile

	public static void BuildMobileControls ()
	{
		UIEngine._instance.GetMoveJoystick ().SetActive (true);
		UIEngine._instance.GetFaceJoystick ().SetActive (true);
	}

	#endregion



	public GameObject GetMoveJoystick ()
	{
		if (this.moveJoystick == null) {
			Debug.Log ("Move Joystick reference null");
		}

		return this.moveJoystick;
	}

	public GameObject GetFaceJoystick ()
	{
		if (this.faceJoystick == null) {
			Debug.Log ("Face Joystick reference null");
		}

		return this.faceJoystick;
	}

	#region desktop

	public static void BuildDesktopControls ()
	{

	}

	#endregion
}
