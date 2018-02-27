using System;
using UnityEngine;

namespace Helix.Components.Skills
{
    public class MeleeBasicSkill : DirectionalSkill
    {
        public MeleeBasicSkill()
        {            
            this._identifier = "MeleeBasicSkill";
            this.Range = 1;
        }

        public override void Implementation()
        {
            Debug.Log("Melee implementation called"); 
        }
    }
}

