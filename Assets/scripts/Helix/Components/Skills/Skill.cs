using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Skills.Events;
using Helix.Components.Operator;

namespace Helix.Components.Skills
{
    public abstract class Skill
    {
        
        public event SkillFired SkillBegun;
        public event ShouldDealDamage shouldDealDamage;

        protected string _identifier;
        //default cooldown in seconds
        protected float _cooldown = 2.0f;
        protected DateTime _lastCasted = DateTime.Now;

        public void Begin() //checks cooldown here
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime > _lastCasted.AddSeconds(_cooldown))
            {
                //Debug.Log(string.Format("Firing skill with identifier {0}", this._identifier));
                if (this.SkillBegun != null)
                {
                    this.SkillBegun(this, new SkillFiredArgs());   
                }
            }
        }

        public string GetIdentifier()
        {
            return this._identifier;
        }

        public virtual void Execute(Player caster) //override must use base.Execute(),because this sets cooldown to begin
        {            
            _lastCasted = DateTime.Now;
        }

        public void DealDamage(Operator.Operator receiver, DamageType damageType, float damageAmount)
        {
            if (shouldDealDamage != null)
            {
                shouldDealDamage(this, new ShouldDealDamageArgs(receiver, damageType, damageAmount));
            }
        }
    }

    public enum SkillType
    {
        primary,
        moveSkillPrimary,
        moveSkillSecondary,
        attackSkillPrimary,
        attackSkillSecondary
    }
}
