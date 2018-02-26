using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helix.Components.Skills.Events
{
    public class SkillFiredArgs : System.EventArgs
    {
        public SkillFiredArgs()
        {
        }
    }

    public delegate void SkillFired(object sender,SkillFiredArgs args);
}