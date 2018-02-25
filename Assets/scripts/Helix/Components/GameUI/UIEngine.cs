using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Controllers;

public class UIEngine : MonoBehaviour
{

    //events
    public static event UIEngineEvent ShouldBuildUI;

    //UI Object references
    public GameObject moveJoystick;
    public GameObject fireJoystick;

    //singleton
    private static UIEngine _instance;

    UIEngine()
    {

    }

    void Awake()
    { 
        if (_instance == null)
        {
            _instance = this;
        }

        //Event subscriptions
        UIEngine.ShouldBuildUI += UserInputController.GetInstance().GetControls().RequestBuildUI;
    }

    public static UIEngine GetInstance()
    {
        return UIEngine._instance;
    }

    void Start()
    {
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    public void InitUI()
    {
        Debug.Log("Initializing UI...");
        if (UIEngine.ShouldBuildUI != null)
        {
            UIEngine.ShouldBuildUI();
        }
    }

    #region mobile

    public static void BuildMobileControls()
    {
        UIEngine._instance.GetMoveJoystick().SetActive(true);
        UIEngine._instance.GetFireJoystick().SetActive(true);
    }

    #endregion



    public GameObject GetMoveJoystick()
    {
        if (this.moveJoystick == null)
        {
            Debug.Log("Move Joystick reference null");
        }

        return this.moveJoystick;
    }

    public GameObject GetFireJoystick()
    {
        if (this.fireJoystick == null)
        {
            Debug.Log("Fire Joystick reference null");
        }

        return this.fireJoystick;
    }

    #region desktop

    public static void BuildDesktopControls()
    {

    }

    #endregion
}
