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

        public override void Implementation(Player caster)
        {
            Debug.Log("Melee implementation called"); 
            this._lastCasted = DateTime.Now;

            Collider[] targets = Physics.OverlapBox(caster.transform.position + caster.transform.forward + caster.transform.up / 2 + new Vector3(0, 0.1f, 0), new Vector3(this.Range, 0.5f, this.Range), caster.transform.rotation);


            foreach (Collider target in targets)
            {
                Debug.Log(target.gameObject.name);
            }

        }
    }
}

