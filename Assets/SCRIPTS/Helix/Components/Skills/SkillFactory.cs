using System;
using UnityEngine;

namespace Helix.Components.Skills
{
    public class SkillFactory
    {
        public static SkillFactory _instance;

        public SkillFactory()
        {
            if (SkillFactory._instance == null)
            {
                SkillFactory._instance = this;
            }    
        }

        public static SkillFactory GetInstance()
        {
            return SkillFactory._instance;
        }

        public static Skill GetSkillWithIdentifier(string identifier)
        {
            Type skillType = Type.GetType("Helix.Components.Skills." + identifier);
            if (skillType == null)
            {
                Debug.Log("Skill class does not exist: " + identifier);
                return null;
            }
            else
            {                
                return (Skill)Activator.CreateInstance(skillType);
            }
        }


    }
}

