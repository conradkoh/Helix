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

    public Animator anim;

    private bool attackAnimCommited;

    public Player()
    {
    }

    public void Awake()
    {
        this._operator = new Operator(new OperatorStats(this.health, 0, 0, 0, 50f));
    }

    public void Start()
    {
        InitPlayer(); //ideally this should be called by subscribing to an event on GameEngine, but im putting it here first to get it out of the way
    }



    public void InitPlayer()
    {
        controller.Fire += Fire;
        controller.Move += Move;
        controller.Face += Face;
        controller.Animate += Animate;

        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Log("Animator not found on player");
        }
    }

    public void Fire(object sender, FireIntentSpecifiedArgs args)
    {        
        Debug.Log(this._operator.GetSummary());

        //face direction to fire
        Face(this, new FaceIntentSpecifiedArgs(args.direction));

    }

    public void Move(object sender, MoveIntentSpecifiedArgs args)
    {
        //Debug.Log(String.Format("Player Moving x: {0}, y: {1}", args.direction.x, args.direction.y));
        transform.position = new Vector3(args.direction.x, 0, args.direction.y) * _operator.GetStats().movementSpeed / 1000 + transform.position;

    }

    public void Face(object sender, FaceIntentSpecifiedArgs args)
    {
        //Debug.Log(String.Format("Player Facing x: {0}", args.direction));

        if (!attackAnimCommited)
        {            
            transform.rotation = args.direction;   
        }
    }


    public void Animate(object sender, AnimateIntentSpecifiedArgs args)
    {

        switch (args.state)
        {
            case AnimateState.None:
                {
                    anim.SetInteger("isRunning", 0);
                    anim.SetBool("isAttackingMelee", false);                      
                    break;
                }
            case AnimateState.Run:
                {                    
                    anim.SetInteger("isRunning", 1);   
                    break;
                }
            case AnimateState.StopRun:
                {                    
                    anim.SetInteger("isRunning", 0);   
                    break;
                }
            case AnimateState.Attack:
                {
                    anim.SetBool("isAttackingMelee", true);
                    break;
                }
            case AnimateState.StopAttack:
                {
                    anim.SetBool("isAttackingMelee", false);
                    attackAnimCommited = false;
                    break;
                }

        }                
    }

    public void HitAnimEvent()
    {
        Debug.Log("Hit Animation Event");
    }

    public void CommitAttackAnimEvent()
    {
        //disable rotation   
        attackAnimCommited = true;
    }


}