using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Controllers;

public class Main : MonoBehaviour
{
    private User _user;

    void Awake()
    {        
        
    }

    // Use this for initialization
    void Start()
    {
        this._user = gameObject.AddComponent<User>(); //Instantiate the user

        UIEngine.GetInstance().InitUI();
        UserInputController.GetInstance().Initcontrols();
    }
	
    // Update is called once per frame
    void Update()
    {
    }
}
