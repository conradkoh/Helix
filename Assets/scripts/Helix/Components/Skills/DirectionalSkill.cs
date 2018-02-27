using System;

namespace Helix.Components.Skills
{
    public abstract class DirectionalSkill : Skill
    {
        public float Range { get; set; }

        public float Damage { get; set; }

        public DirectionalSkill(float range, float damage)
        {
            this.Range = range;
            this.Damage = damage;
        }

        public DirectionalSkill()
        {
            
        }

        public override void Execute()
        {
            Implementation();
        }

        public abstract void Implementation();
    }
}

