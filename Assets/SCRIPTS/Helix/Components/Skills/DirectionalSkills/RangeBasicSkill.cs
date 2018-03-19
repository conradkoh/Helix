using System;
using UnityEngine;
using Helix.Components.Operator;

namespace Helix.Components.Skills
{
    public class RangeBasicSkill : DirectionalSkill
    {
        
        public float attack;

        public RangeBasicSkill()
        {
            this._identifier = "RangeBasicSkill";
            this.range = 10;
        }

        public override void Implementation(Player caster)
        {
            Debug.Log("Range implementation called"); 
            this._lastCasted = DateTime.Now;

            GameObject projectile = GameObject.Instantiate(PrefabManager.GetInstance().rectangleProjectile) as GameObject;
            projectile.name = caster.name + " rangeBasicSkill";

            SimpleProjectile sp = projectile.AddComponent<SimpleProjectile>();

            Vector3 start = caster.transform.position + new Vector3(0, 0.5f, 0);
            Vector3 direction = new Vector3(caster.transform.forward.x, 0f, caster.transform.forward.z);
            float speed = 0.2f;

            sp.Initialize(speed, start, direction, range);
            sp.onCollision += OnCollision;

            attack = caster.GetAttack();
            
        }

        public void OnCollision(ProjectileEventArgs args)
        {
            
            if (args.target.tag == "Enemy")
            {
                DealDamage(args.target.GetComponent<Enemy>().GetOperator(), DamageType.physical, attack);   
                GameObject.Destroy(args.sender.gameObject);
            }
        }
    }
}

