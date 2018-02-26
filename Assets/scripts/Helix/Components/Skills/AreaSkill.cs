using System;

namespace Helix.Components.Skills
{
    public abstract class AreaSkill : Skill
    {
        public float Radius { get; set; }

        public float Damage { get; set; }

        public AreaSkill(float radius, float damage)
        {   
            this.Radius = radius;
            this.Damage = damage;
        }
    }
}

