using System;

namespace Helix.Components.Skills
{
    public abstract class DirectionalSkill : Skill
    {
        public float range { get; set; }

        public float damage { get; set; }


        public DirectionalSkill(float range, float damage)
        {
            this.range = range;
            this.damage = damage;
        }

        public DirectionalSkill()
        {
            
        }

        public override void Execute(Player caster)
        {
            base.Execute(caster); //IMPORTANT, sets cooldown to begin
            Implementation(caster);
        }

        public abstract void Implementation(Player caster);
    }
}

