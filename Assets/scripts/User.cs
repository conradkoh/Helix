using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Controllers;

public class User : MonoBehaviour
{
    public UserInputController playerControlsController;
    // Use this for initialization
    void Awake()
    {
        InitUser();
        //Main.ShouldInitControls += InitUser;
    }

    public void InitUser()
    {
        Debug.Log("Initializing User...");
        this.playerControlsController = UserInputController.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {        
        this.playerControlsController.CheckPlayerMoving();    
        this.playerControlsController.CheckPlayerFacing();
        this.playerControlsController.CheckPlayerFiring();   //called last, because when firing override moving
        this.playerControlsController.Update();
    }


}
