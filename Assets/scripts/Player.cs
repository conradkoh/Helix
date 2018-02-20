using System;
using UnityEngine;
using Helix.Components.Controls.Controllers;
using Helix.Components.Controls.Events;
using Helix.Components.Operator;

public class Player : MonoBehaviour
{
    UserInputController controller = UserInputController.GetInstance();
    public float health = 0;
    private Operator _operator;

    public Player()
    {
    }

    public void Awake()
    {   
        this._operator = new Operator(new OperatorStats(this.health));
        controller.Fire += Fire;
        controller.Move += Move;
    }

    public void Fire(object sender, FireIntentSpecifiedArgs args)
    {
        Debug.Log("Player Firing!");
        Debug.Log(this._operator.GetSummary());
    }

    public void Move(object sender, MoveIntentSpecifiedArgs args)
    {
        Debug.Log(String.Format("Player Moving x: {0}, y: {1}", args.direction.x, args.direction.y));
    }
}