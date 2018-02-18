using System;
using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
    public class DesktopUserControl: UserInputControl
    {
        public DesktopUserControl()
        {
        }

        public override bool ShouldPlayerFire()
        {
            return true;
        }

        public override Vector2 GetPlayerMovementDirection()
        {
            return new Vector2(1, 1);
        }
    }
}