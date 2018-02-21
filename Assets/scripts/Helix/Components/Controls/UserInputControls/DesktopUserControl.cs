using System;
using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
	public class DesktopUserControl: UserInputControl
	{

		public Vector2 faceControlInitial = Vector2.zero;
		public bool faceControlActive = false;

		public DesktopUserControl()
		{
			//event subscriptions
			UIEngine.ShouldBuildUI += RequestBuildMobileUI;
		}

		public override bool ShouldPlayerFire()
		{
			return false;
		}

		public override Vector2 GetPlayerMovementDirection()
		{

			Vector2 output = new Vector2(0, 0);
			if (Input.GetKey(KeyCode.W))
			{
				output += new Vector2(0, 1);
			}
			if (Input.GetKey(KeyCode.A))
			{
				output += new Vector2(-1, 0);
			}
			if (Input.GetKey(KeyCode.S))
			{
				output += new Vector2(0, -1);
			}
			if (Input.GetKey(KeyCode.D))
			{
				output += new Vector2(1, 0);
			}
				
			return output;
		}

		public override bool GetPlayerShouldMove()
		{
			return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
		}

		public override Quaternion GetPlayerFaceDirection()
		{
			Vector2 mousePosition = Input.mousePosition;

			if (faceControlActive)
			{
				//follow mouse
				Vector2 directionVector = mousePosition - faceControlInitial;
				float output = Mathf.Rad2Deg * Mathf.Atan2(directionVector.x, directionVector.y);
				return Quaternion.Euler(0, output, 0);

			}
			else
			{
				//follow walking direction
				Vector2 directionVector = GetPlayerMovementDirection();
				float output = Mathf.Rad2Deg * Mathf.Atan2(directionVector.x, directionVector.y);
				return Quaternion.Euler(0, output, 0);
			}				
		}

		public override bool GetPlayerShouldFace()
		{
			return faceControlActive || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
		}

		public override void Update()
		{
			if (Input.GetMouseButtonDown(0) && !faceControlActive) //start face control
			{
				faceControlActive = true;
				faceControlInitial = Input.mousePosition;
			}

			if (Input.GetMouseButtonUp(0) && faceControlActive) //end face control
			{
				faceControlActive = false;
				faceControlInitial = Vector2.zero;
			}
		}

		public void RequestBuildMobileUI()
		{
			UIEngine.BuildDesktopControls();
		}
	}
}