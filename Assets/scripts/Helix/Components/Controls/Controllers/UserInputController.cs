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

		private UserInputControls.UserInputControl _controls;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserInputController"/> class.
		/// </summary>
		private UserInputController ()
		{
			this._controls = UserInputControlFactory.GetControls ();
		}

		/// <summary>
		/// Gets the UserInputController singleton
		/// </summary>
		/// <returns>The instance.</returns>
		public static UserInputController GetInstance ()
		{
			if (UserInputController._instance == null) {
				UserInputController._instance = new UserInputController ();
			}
			return UserInputController._instance;
		}

		/// <summary>
		/// Checks if the player is firing given input controls
		/// </summary>
		/// <param name="controls">Controls.</param>
		public void CheckPlayerFiring ()
		{
			if (this._controls.ShouldPlayerFire ()) {
				if (this.Fire != null) {
					this.Fire (this, null); 
				}
			}
		}

		public void CheckPlayerMoving ()
		{
			Vector2 direction = this._controls.GetPlayerMovementDirection ();
			if (direction != Vector2.zero && this.Move != null) {
				this.Move (this, new MoveIntentSpecifiedArgs (direction));
			}
		}

		public void CheckPlayerFacing ()
		{
			Quaternion direction = this._controls.GetPlayerFaceDirection ();
			this.Face (this, new FaceIntentSpecifiedArgs (direction)); 

		}

	}
}