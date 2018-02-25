using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Events;
using Helix.Components.Controls.UserInputControls;

namespace Helix.Components.Controls.Controllers
{

    public class UserInputController
    {
        private static UserInputController _instance = null;

        public event FireIntentSpecified Fire;
        public event MoveIntentSpecified Move;
        public event FaceIntentSpecified Face;
        public event AnimateIntentSpecified Animate;

        private UserInputControls.UserInputControl _controls;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInputController"/> class.
        /// </summary>
        private UserInputController()
        {
            this._controls = UserInputControlFactory.GetControls();
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


        /// <summary>
        /// Checks if the player is firing given input controls
        /// </summary>
        /// <param name="controls">Controls.</param>
        public void CheckPlayerFiring()
        {
            if (this._controls.ShouldPlayerFire() && this.Fire != null)
            {
                Quaternion direction = this._controls.GetPlayerAimDirection();
                this.Fire(this, new FireIntentSpecifiedArgs(direction)); 
                this.Animate(this, new AnimateIntentSpecifiedArgs(AnimateState.Attack, direction));
            }
            else
            {
                this.Animate(this, new AnimateIntentSpecifiedArgs(AnimateState.StopAttack, Quaternion.identity)); 
            }
        }

        public void CheckPlayerMoving()
        {
            Vector2 direction = this._controls.GetPlayerMovementDirection();

            if (this._controls.GetPlayerShouldMove() && !this._controls.ShouldPlayerFire() && this.Move != null)
            {   
                this.Move(this, new MoveIntentSpecifiedArgs(direction));
                this.Animate(this, new AnimateIntentSpecifiedArgs(AnimateState.Run, this._controls.GetPlayerFaceDirection()));
            }
            else
            {
                if (this.Animate != null)
                {
                    this.Animate(this, new AnimateIntentSpecifiedArgs(AnimateState.StopRun, Quaternion.identity));
                }
            }
        }

        public void CheckPlayerFacing()
        {
            if (this.Face != null && this._controls.GetPlayerShouldMove())
            {
                //Face the direction youre moving
                Vector2 moveDirection = this._controls.GetPlayerMovementDirection();
                float faceDirection = Mathf.Rad2Deg * Mathf.Atan2(moveDirection.x, moveDirection.y);
                Quaternion direction = Quaternion.Euler(0, faceDirection, 0);
                this.Face(this, new FaceIntentSpecifiedArgs(direction));    
            }			
        }

        public void Update()
        {
            this._controls.Update();
        }

    }
}