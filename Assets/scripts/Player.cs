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

    public void Fire(object sender, PlayerFiredArgs args)
    {
        Debug.Log("Player Firing!");
    }
}