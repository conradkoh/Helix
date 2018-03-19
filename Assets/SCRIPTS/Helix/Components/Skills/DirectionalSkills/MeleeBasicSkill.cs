using System;
using UnityEngine;
using Helix.Components.Operator;

namespace Helix.Components.Skills
{
    public class MeleeBasicSkill : DirectionalSkill
    {
        public MeleeBasicSkill()
        {            
            this._identifier = "MeleeBasicSkill";
            this.range = 1;
        }

        public override void Implementation(Player caster)
        {
            Debug.Log("Melee implementation called"); 
            this._lastCasted = DateTime.Now;

            Collider[] targets = Physics.OverlapBox(caster.transform.position + caster.transform.forward + caster.transform.up / 2 + new Vector3(0, 0.1f, 0), new Vector3(this.range, 0.5f, this.range), caster.transform.rotation);

            float distance = Mathf.Infinity;
            Enemy finalTarget = null;

            //find closest target
            foreach (Collider target in targets)
            {
                Enemy thisOperator = target.gameObject.GetComponent<Enemy>();
                if (thisOperator != null)
                {
                    float targetDistance = Vector3.Distance(target.transform.position, caster.transform.position);
                    if (targetDistance < distance)
                    {
                        distance = targetDistance;
                        finalTarget = thisOperator;
                    }   
                }
            }
                               

            if (finalTarget != null)
            {
                DealDamage(finalTarget.GetOperator(), DamageType.physical, caster.GetAttack());   
            }
        }
    }
}

