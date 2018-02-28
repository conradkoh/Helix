using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Skills;

namespace Helix.Components.Controls.Events
{
    public class CastIntentSpecifiedArgs : System.EventArgs
    {
        public SkillType skillType { get; set; }

        public Quaternion direction { get; set; }


        public CastIntentSpecifiedArgs(SkillType skillType, Quaternion direction)
        {
            this.direction = direction;
            this.skillType = skillType;
        }
    }

    public delegate void CastIntentSpecified(object sender,CastIntentSpecifiedArgs args);
}