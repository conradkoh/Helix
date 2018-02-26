using System;
using System.Collections.Generic;

namespace Helix.Components.Skills
{
    public class SkillSet
    {
        private List<Skill> _skills = new List<Skill>();
        private Skill _primarySkill;
        private Skill _secondarySkill;

        public SkillSet()
        {
        }

        public void Load(List<Skill> skills)
        {
            this._skills = skills;
        }

        public void Add(Skill skill)
        {
            this._skills.Add(skill);
        }

        public void Remove(Skill skill)
        {
            this._skills.Remove(skill);
        }

        public void BindPrimary(string identifier)
        {
            foreach (Skill skill in this._skills)
            {
                if (skill.GetIdentifier() == identifier)
                {
                    this._primarySkill = skill;
                }
            }
        }

        public void BindSecondary(string identifier)
        {
            foreach (Skill skill in this._skills)
            {
                if (skill.GetIdentifier() == identifier)
                {
                    this._secondarySkill = skill;
                }
            }
        }

        public void UsePrimary()
        {
            if (this._primarySkill != null)
            {
                this._primarySkill.Fire();
            }
        }

        public void UseSecondary()
        {
            if (this._secondarySkill != null)
            {
                this._secondarySkill.Fire();
            }
        }
    }
}

