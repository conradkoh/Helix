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
            this.Range = 10;
        }

        public override void Implementation(Player caster)
        {
            Debug.Log("Melee implementation called"); 
            this._lastCasted = DateTime.Now;

            GameObject projectile = GameObject.Instantiate(PrefabManager.GetInstance().rectangleProjectile) as GameObject;
            //new GameObject(caster.name + " rangeBasicSkill");
            SimpleProjectile sp = projectile.AddComponent<SimpleProjectile>();
            sp.Initialize(0.2f, caster.transform.position, caster.transform.forward, 10);
            sp.onCollision += OnCollision;

            attack = caster.GetAttack();
            
        }

        public void OnCollision(ProjectileEventArgs args)
        {
            
            if (args.target.tag == "Enemy")
            {
                Debug.Log("enemy");
                DealDamage(args.target.GetComponent<Enemy>().GetOperator(), DamageType.physical, attack);   
                GameObject.Destroy(args.sender.gameObject);
            }
        }
    }
}

