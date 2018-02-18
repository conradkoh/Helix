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
            return false;
        }

        public override Vector2 GetPlayerMovementDirection()
        {

			Vector2 output = new Vector2 (0, 0);
			if(Input.GetKey(KeyCode.W))
			{
				output += new Vector2 (0, 1);
			}
			if(Input.GetKey(KeyCode.A))
			{
				output += new Vector2 (-1, 0);
			}
			if(Input.GetKey(KeyCode.S))
			{
				output += new Vector2 (0, -1);
			}
			if(Input.GetKey(KeyCode.D))
			{
				output += new Vector2 (1, 0);
			}
				
			return output;
        }
    }
}