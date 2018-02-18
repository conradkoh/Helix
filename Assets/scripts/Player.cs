using System;
using UnityEngine;
using Helix.Components.Controls.Controllers;
using Helix.Components.Controls.Events;

public class Player : MonoBehaviour
{
    UserInputController controller = UserInputController.GetInstance();

    public Player()
    {

    }

    public void Awake()
    {
        controller.Fire += Fire;
    }

    public void Fire(object sender, FireIntentSpecifiedArgs args)
    {
        Debug.Log("Player Firing!");
    }

    public void Move(Vector2 direction){

    }
}