using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
    public abstract class UserInputControl
    {
	
        public abstract bool ShouldPlayerFire();

        public abstract void ShouldPlayerMove();

    }
}