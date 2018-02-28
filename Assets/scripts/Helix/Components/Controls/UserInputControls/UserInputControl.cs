using UnityEngine;
using Helix.Components.Skills;

namespace Helix.Components.Controls.UserInputControls
{
    public abstract class UserInputControl
    {

        public ControlMoveIntent DidIntendMove;
        public ControlMoveIntent DidIntendMoveEnd;
        public ControlCastIntent DidIntendCast;
        public ControlCastIntent DidIntendCastEnd;


        public abstract void Update();

        public abstract void InitControls();

        public abstract void RequestBuildUI();
    }

    public delegate void ControlMoveIntent(Vector2 directionVector);
    public delegate void ControlCastIntent(SkillType skillType,Quaternion direction);
}