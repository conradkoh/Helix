using System;
using UnityEngine;

namespace Helix.Components.Skills
{
    public class BasicSkill1 : DirectionalSkill
    {
        public BasicSkill1(float range, float damage)
            : base(range, damage)
        {
            this._identifier = "bs1";
        }
    }
}

