﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Controllers;
using Helix.Components.Controls.Events;
using Helix.Components.Operator;
using Helix.Components.Skills;
using Helix.Components.Skills.Events;
using Helix.Components.Equipment;

public class Player : MonoBehaviour
{
    UserInputController controller = UserInputController.GetInstance();
    public float health = 0;
    private Operator _operator;
    private SkillSet _skillSet;
    public Animator anim;

    public string committedSkillIdentifier = "";

    public bool isToldToFire = false;
    public bool isToldToMove = false;


    public Player()
    {
    }

    public void Awake()
    {

    }

    public void Start()
    {
        InitPlayer(); //ideally this should be called by subscribing to an event on GameEngine, but im putting it here first to get it out of the way
    }


    public void InitPlayer()
    {

        this._operator = new Operator(new OperatorStats(this.health, 0, 10, 0, 50f));
        try
        {
            var test_item_properties = new Dictionary<EQUIPMENTSTATS, float>();
            test_item_properties.Add(EQUIPMENTSTATS.ATTACK, 20f);
            var test_item = new TestItem1(test_item_properties);
            this._operator.Equip(test_item);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        //control event subscriptions
        //controller.Fire += Fire;
        controller.Move += Move;
        controller.Face += Face;
        controller.Cast += Cast;
        controller.MoveEnd += MoveEnd;
        controller.CastEnd += CastEnd;

        //skill initialization
        this._skillSet = new SkillSet();
        this._skillSet.shouldDealDamage += DealDamage;

        var skill = this._skillSet.AddSkillWithIdentifier("RangeBasicSkill");
        skill.SkillBegun += this.SkillBegun;
        _skillSet.BindPrimary("RangeBasicSkill"); //Temporary hard code of skills for testing


        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Log("Animator not found on player");
        }
    }

    public void Cast(object sender, CastIntentSpecifiedArgs args)
    {        
        isToldToFire = true;
        Face(this, new FaceIntentSpecifiedArgs(args.direction));

        switch (args.skillType)
        {
            case SkillType.primary:
                {
                    this._skillSet.BeginPrimary();
                    break;
                }

            case SkillType.attackSkillPrimary:
                {                    
                    break;   
                }
            case SkillType.attackSkillSecondary:
                {
                    break;   
                }
            case SkillType.moveSkillPrimary:
                {
                    break;   
                }
            case SkillType.moveSkillSecondary:
                {
                    break;   
                }

        }

    }

    public void CastEnd(object sender, CastIntentSpecifiedArgs args)
    {
        isToldToFire = false;
        if (this.IsCommitted())
        {
            //Animate(AnimateState.StopAttack);   
        }
    }

    public void Move(object sender, MoveIntentSpecifiedArgs args)
    {        
        isToldToMove = true;

        if (committedSkillIdentifier == "")
        {
            if (isToldToFire)
            {
                Animate("EndRun");
            }
            else
            {
                transform.position = new Vector3(args.direction.x, 0, args.direction.y).normalized * _operator.GetStats().movementSpeed / 1000 + transform.position;

                float faceAngle = Mathf.Rad2Deg * Mathf.Atan2(args.direction.x, args.direction.y);
                Face(this, new FaceIntentSpecifiedArgs(Quaternion.Euler(0, faceAngle, 0)));

                //cancel skill movement if hasCurrent but hasnt committed
                SkillCancel();
                Animate("Run");
            }
        }
    }

    public void MoveEnd(object sender, MoveIntentSpecifiedArgs args)
    {
        isToldToMove = false;
        Animate("EndRun");
    }


    public void Face(object sender, FaceIntentSpecifiedArgs args)
    {
        //Debug.Log(String.Format("Player Facing x: {0}", args.direction));

        if (!this.IsCommitted())
        {            
            transform.rotation = args.direction;   
        }
    }


    public void Animate(string state)
    {

        switch (state)
        {
            case "Clear":
                {
                    anim.SetInteger("isRunning", 0);
                    anim.SetBool("isAttackingMelee", false);                      
                    break;
                }
            case "Run":
                {                    
                    anim.SetInteger("isRunning", 1);   
                    break;
                }
            case "EndRun":
                {                    
                    anim.SetInteger("isRunning", 0);   
                    break;
                }
            case "Attack":
                {
                    //anim.SetBool("isAttackingMelee", true);
                    break;
                }
            case "DeCommitAttack":
                {
                    this.committedSkillIdentifier = "";
                    break;
                }
            case "EndAttack":
                {
                    anim.SetBool("isAttackingMelee", false);
                    break;
                }

        }                
    }


    public void SkillBegun(object sender, SkillFiredArgs args) // animation begins
    {
        //cancel current if need be
        SkillCancel();

        //set current
        this._skillSet.SetCurrent((Skill)sender);

        //begin animation
        anim.SetBool("isAttackingMelee", true);
    }

    public void SkillCancel()
    {
        if (this._skillSet.HasCurrent())
        {
            this._skillSet.CancelCurrent();
        }

        if (!this.IsCommitted())
        {
            Animate("Clear"); 
        }
    }

    public void SkillAnimCommit(string skillIdentifier)
    {
        this.committedSkillIdentifier = skillIdentifier;
    }
        
    //this is where skill is actually executed
    public void SkillAnimMainExecute()
    {
        //Debug.Log(this._operator.GetSummary());
        Skill current = this._skillSet.ExecuteCurrent(this);
    }

    public void SkillAnimCommitEnd()
    {
        //anim.SetBool("isAttackingMelee", false);
        Animate("DeCommitAttack");
    }

    public void SkillAnimCompleted()
    {
        Animate("EndAttack");
    }

    public void DealDamage(System.Object sender, ShouldDealDamageArgs args)
    {
        Operator playerOp = args.damageReceiver;
        if (playerOp != null)
        {
            playerOp.TakeDamage(args.damageAmount);
        }

    }


    #region operator

    public float GetAttack()
    {
        return _operator.GetStats().attack;
    }

    #endregion


    private bool IsCommitted()
    {
        return committedSkillIdentifier != "";
    }
}