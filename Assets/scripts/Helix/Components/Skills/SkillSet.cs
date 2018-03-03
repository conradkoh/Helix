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
            this._skills.Clear();
            foreach (Skill skill in this._skills)
            {
                this.Add(skill);
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
            skill.shouldDealDamage += ShouldDealDamage; //subscribe to skill's shoulddealdamage event
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

        public void BeginSecondary()
        {
            if (this._secondarySkill != null)
            {
                this._secondarySkill.Begin();
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

        public Skill ExecuteCurrent(Player caster)
        {
            this.current.Execute(caster);

            return current;
        }

        public void CancelCurrent()
        {
            this.current = null;
        }


        public void ShouldDealDamage(System.Object sender, ShouldDealDamageArgs args)
        {
            if (this.shouldDealDamage != null)
            {
                this.shouldDealDamage(sender, args);
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

