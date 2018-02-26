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
    public GameObject tetherStart;
    public GameObject tetherEnd;
    public GameObject tether;
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

    public static void SpawnTether()
    {
        UIEngine.GetInstance().tetherStart.SetActive(true);
        UIEngine.GetInstance().tether.SetActive(true);
        UIEngine.GetInstance().tetherEnd.SetActive(true);
    }

    public static void HideTether()
    {
        UIEngine.GetInstance().tetherStart.SetActive(false);
        UIEngine.GetInstance().tether.SetActive(false);
        UIEngine.GetInstance().tetherEnd.SetActive(false);
    }

    public static void UpdateTether(Vector2 startPos, Vector2 currentPos)
    {   
        float x = startPos.x - (startPos.x - currentPos.x) / 2;
        float y = startPos.y - (startPos.y - currentPos.y) / 2;
        Vector2 finalVector = startPos - currentPos;

        UIEngine.GetInstance().tetherStart.GetComponent<RectTransform>().position = startPos;
        UIEngine.GetInstance().tetherEnd.GetComponent<RectTransform>().position = currentPos;
        RectTransform tetherRT = UIEngine.GetInstance().tether.GetComponent<RectTransform>();
        tetherRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Vector2.Distance(startPos, currentPos));
        tetherRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 10);
        tetherRT.SetPositionAndRotation(new Vector3(x, y, 0), Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(finalVector.y, finalVector.x)));
    }

    #endregion
}
