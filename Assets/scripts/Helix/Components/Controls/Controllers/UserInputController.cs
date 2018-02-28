using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Events;
using Helix.Components.Controls.UserInputControls;
using Helix.Components.Skills;

namespace Helix.Components.Controls.Controllers
{

    public class UserInputController
    {
        private static UserInputController _instance = null;

        public event FireIntentSpecified Fire;
        public event MoveIntentSpecified Move;
        public event MoveIntentSpecified MoveEnd;
        public event FaceIntentSpecified Face;
        public event CastIntentSpecified Cast;
        public event CastIntentSpecified CastEnd;
        public event AnimateIntentSpecified Animate;

        private UserInputControls.UserInputControl _controls;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInputController"/> class.
        /// </summary>
        private UserInputController()
        {
            this._controls = UserInputControlFactory.GetControls();

            //subscribe events
            this._controls.DidIntendCast += PlayerDidIntendCast;
            this._controls.DidIntendMove += PlayerDidIntendMove;

            this._controls.DidIntendMoveEnd += PlayerDidIntendMoveEnd;
            this._controls.DidIntendCastEnd += PlayerDidIntendCastEnd;
        }

        public void PlayerDidIntendCast(SkillType skillType, Quaternion direction)
        {
            if (this.Cast != null)
            {                                
                this.Cast(this, new CastIntentSpecifiedArgs(skillType, direction));
            }
        }

        public void PlayerDidIntendCastEnd(SkillType skillType, Quaternion direction)
        {
            if (this.CastEnd != null)
            {                                
                this.CastEnd(this, new CastIntentSpecifiedArgs(skillType, Quaternion.identity));
            }
        }

        public void PlayerDidIntendMove(Vector2 directionVector)
        {
            if (this.Move != null)
            {
                this.Move(this, new MoveIntentSpecifiedArgs(directionVector));
            }
        }

        public void PlayerDidIntendMoveEnd(Vector2 directionVector)
        {
            if (this.MoveEnd != null)
            {
                this.MoveEnd(this, new MoveIntentSpecifiedArgs(Vector2.zero));
            }
        }

        /// <summary>
        /// Gets the UserInputController singleton
        /// </summary>
        /// <returns>The instance.</returns>
        public static UserInputController GetInstance()
        {
            if (UserInputController._instance == null)
            {
                UserInputController._instance = new UserInputController();
            }
            return UserInputController._instance;
        }

        public void Initcontrols()
        {
            this._controls.InitControls();
        }

        public UserInputControl GetControls()
        {
            return this._controls;
        }

        public void Update()
        {
            this._controls.Update();
        }
    }
}