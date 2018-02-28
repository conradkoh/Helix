using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Skills.Events;

namespace Helix.Components.Skills
{
    public abstract class Skill
    {
        
        public event SkillFired SkillFired;

        protected string _identifier;
        //default cooldown in seconds
        protected float _cooldown = 2.0f;

        protected DateTime _lastCasted = DateTime.Now;

        public void Fire()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime > _lastCasted.AddSeconds(_cooldown))
            {
                //Debug.Log(string.Format("Firing skill with identifier {0}", this._identifier));
                if (this.SkillFired != null)
                {
                    this.SkillFired(this, new SkillFiredArgs());   
                }
                Execute();
                this._lastCasted = DateTime.Now;
            }
        }

        public string GetIdentifier()
        {
            return this._identifier;
        }

        public abstract void Execute();
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
