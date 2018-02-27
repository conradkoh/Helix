using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

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

        public Skill AddSkillWithIdentifier(string identifier)
        {
            Skill skill = SkillWithIdentifier(identifier);         

            if (skill != null)
            {
                this._skills.Add(skill);
            }

            return skill;
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
            this._primarySkill = SkillInSetWithIdentifier(identifier);
        }

        public void BindSecondary(string identifier)
        {
            this._secondarySkill = SkillInSetWithIdentifier(identifier);     
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

        public Skill SkillInSetWithIdentifier(string identifier)
        {
            Skill skill = _skills.Find(x => x.GetIdentifier() == identifier);

            if (skill == null)
            {
                Debug.Log("Skill not in set: " + identifier);
            }

            return skill;
        }

        public Skill SkillWithIdentifier(string identifier)
        {
            return SkillFactory.GetSkillWithIdentifier(identifier);
        }
    }
}

