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
        private Skill current;

        public ShouldDealDamage shouldDealDamage;

        public SkillSet()
        {
            
        }

        public void Load(List<Skill> skills)
        {
            this._skills = skills;

            foreach (Skill skill in this._skills)
            {
                skill.shouldDealDamage += this.shouldDealDamage; //subscribe to skill's shoulddealdamage event
            }
        }

        public Skill AddSkillWithIdentifier(string identifier)
        {
            Skill skill = SkillWithIdentifier(identifier);         

            if (skill != null)
            {
                this.Add(skill);
            }

            return skill;
        }

        public void Add(Skill skill)
        {
            skill.shouldDealDamage += this.shouldDealDamage; //subscribe to skill's shoulddealdamage event
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

        public void BeginPrimary()
        {
            if (this._primarySkill != null)
            {
                this._primarySkill.Begin(); //checks cooldown, calls event to begin animation
            }
        }

        public void ExecutePrimary()
        {
            if (this._primarySkill != null)
            {
                this._primarySkill.Execute();
            }
        }

        public void BeginSecondary()
        {
            if (this._secondarySkill != null)
            {
                this._secondarySkill.Begin();
            }
        }

        public void ExecuteSecondary()
        {
            if (this._secondarySkill != null)
            {
                this._secondarySkill.Execute();
            }
        }


        public bool HasCurrent()
        {
            return current != null;    
        }

        public Skill GetCurrent()
        {
            return current;
        }

        public void SetCurrent(Skill skill)
        {
            this.current = skill;
        }

        public Skill ExecuteCurrent()
        {
            this.current.Execute();

            return current;
        }

        public void CancelCurrent()
        {
            this.current = null;
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

