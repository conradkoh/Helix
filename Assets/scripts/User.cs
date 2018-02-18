using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Controllers;

public class User : MonoBehaviour
{
    public UserInputController playerControlsController;
    // Use this for initialization
    void Awake ()
    {
        this.playerControlsController = UserInputController.GetInstance ();
    }

    // Update is called once per frame
    void Update ()
    {
        this.playerControlsController.CheckPlayerFiring ();
    }
}
