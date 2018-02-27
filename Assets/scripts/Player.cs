using System;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Controllers;
using Helix.Components.Controls.Events;
using Helix.Components.Operator;
using Helix.Components.Skills;

public class Player : MonoBehaviour
{
    UserInputController controller = UserInputController.GetInstance();
    public float health = 0;
    private Operator _operator;
    private SkillSet _skillSet;
    public Animator anim;

    public string committedSkillIdentifier = "";

    public Player()
    {
    }

    public void Awake()
    {
        this._operator = new Operator(new OperatorStats(this.health, 0, 0, 0, 50f));
        this._skillSet = new SkillSet();
        this._skillSet.AddSkillWithIdentifier("MeleeBasicSkill");
        _skillSet.BindPrimary("MeleeBasicSkill"); //Temporary hard code of skills for testing
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

        this._skillSet.UsePrimary();
    }

    public void Move(object sender, MoveIntentSpecifiedArgs args)
    {
        //Debug.Log(String.Format("Player Moving x: {0}, y: {1}", args.direction.x, args.direction.y));
        transform.position = new Vector3(args.direction.x, 0, args.direction.y) * _operator.GetStats().movementSpeed / 1000 + transform.position;

    }

    public void Face(object sender, FaceIntentSpecifiedArgs args)
    {
        //Debug.Log(String.Format("Player Facing x: {0}", args.direction));

        if (committedSkillIdentifier == "")
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
                    this.SkillAnimCommitEnd();
                    break;
                }

        }                
    }

    public void SkillAnimCommit(string skillIdentifier)
    {
        this.committedSkillIdentifier = skillIdentifier;
    }

    public void SkillAnimCommitEnd()
    {
        this.committedSkillIdentifier = "";
    }

    //this is where skill is actually executed
    public void SkillAnimMainExecute()
    {
        
    }

    public void HitAnimEvent()
    {
        Debug.Log("Hit Animation Event");
    }



}