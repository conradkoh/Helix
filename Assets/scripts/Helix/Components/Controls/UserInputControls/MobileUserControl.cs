using System;
using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
	public class MobileUserControl:UserInputControl
	{
		public GameObject moveJoystick;
		public GameObject faceJoystick;

		public MobileUserControl ()
		{
			//event subscriptions
			Main.ShouldInitControls += InitControls;
			UIEngine.ShouldBuildUI += RequestBuildMobileUI;
		}

		public void InitControls ()
		{
			this.moveJoystick = UIEngine.GetInstance ().GetMoveJoystick ();
			this.faceJoystick = UIEngine.GetInstance ().GetFaceJoystick ();
		}

		public override bool ShouldPlayerFire ()
		{
			return false;
		}

		public override Vector2 GetPlayerMovementDirection ()
		{
			if (moveJoystick != null) {
				
				float joystickOutput = moveJoystick.GetComponent<Joystick> ().outputAngle;

				float x = Mathf.Sin (joystickOutput * Mathf.Deg2Rad);
				float y = Mathf.Cos (joystickOutput * Mathf.Deg2Rad);

				if (Mathf.Abs (x) > 0.5) {
					x = x / Mathf.Abs (x);
				} else {
					x = 0;
				}

				if (Mathf.Abs (y) > 0.5) {
					y = y / Mathf.Abs (y);
				} else {
					y = 0;
				}
					
				return new Vector2 (x, y);
				;
			} else {
				return Vector2.zero;				
			}

		}

		public override Quaternion GetPlayerFaceDirection ()
		{

			Joystick faceJS = faceJoystick.GetComponent<Joystick> ();
			Joystick moveJS = moveJoystick.GetComponent<Joystick> ();


			if (faceJoystick != null && moveJoystick != null) {

				/// <summary>
				/// If face joystick is not moving, face direction follows movement
				/// </summary>
				if (faceJS.isActive) {
					float faceOutput = faceJS.outputAngle;
					return Quaternion.Euler (0, faceOutput, 0);
				} else {
					float moveOutput = moveJS.outputAngle;
					return Quaternion.Euler (0, moveOutput, 0);
				}



			} else {
				return Quaternion.identity;				
			}
		}

		public void RequestBuildMobileUI ()
		{
			UIEngine.BuildMobileControls ();
		}
	}
}