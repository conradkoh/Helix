using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
    public abstract class UserInputControl
    {
	
        public abstract bool ShouldPlayerFire();

        public abstract Vector2 GetPlayerMovementDirection();

        public abstract Quaternion GetPlayerFaceDirection();

        public abstract void Update();
     
    }
}