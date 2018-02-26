using System;

namespace Helix.Components.Skills
{
    public abstract class DirectionalSkill : Skill
    {
        public float Range { get; }

        public float Damage { get; }

        public DirectionalSkill(float range, float damage)
        {
            this.Range = range;
            this.Damage = damage;
        }
    }
}

