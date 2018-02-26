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

        public void Fire()
        {
            Debug.Log(string.Format("Firing skill with identifier {0}", this._identifier));
            if (this.SkillFired != null)
            {
                this.SkillFired(this, new SkillFiredArgs());   
            }
        }

        public string GetIdentifier()
        {
            return this._identifier;
        }
    }
}
