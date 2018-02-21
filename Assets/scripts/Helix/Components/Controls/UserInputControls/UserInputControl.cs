using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
    public abstract class UserInputControl
    {
	
        public abstract bool ShouldPlayerFire();

        public abstract bool GetPlayerShouldMove();

        public abstract Vector2 GetPlayerMovementDirection();

        public abstract bool GetPlayerShouldFace();

        public abstract Quaternion GetPlayerFaceDirection();

        public abstract void Update();
     
    }
}