using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
    public abstract class UserInputControl
    {
	
        public abstract bool ShouldPlayerFire();

        public abstract bool GetPlayerShouldMove();

        public abstract Vector2 GetPlayerMovementDirection();

        public abstract Quaternion GetPlayerAimDirection();

        public abstract Quaternion GetPlayerFaceDirection();

        public abstract void Update();

        public abstract void InitControls();

        public abstract void RequestBuildUI();

    }
}