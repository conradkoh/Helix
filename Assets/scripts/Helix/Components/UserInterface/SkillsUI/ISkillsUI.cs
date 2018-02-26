using System;
using Helix.Components.Skills.Events;

namespace Helix.Components.UserInterface.SkillsUI
{
    public interface ISkillsUI
    {
        void SkillFired(object sender, SkillFiredArgs args);
    }
}