using System;
using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
    public class MobileUserControl:UserInputControl
    {
		public GameObject _joystick;
        public MobileUserControl()
        {
			//event subscriptions
			Main.ShouldInitControls += InitControls;
			UIEngine.ShouldBuildUI += RequestBuildMobileUI;
        }

		public void InitControls()
		{
			this._joystick = UIEngine.GetInstance ().GetJoystick ();
		}

        public override bool ShouldPlayerFire()
        {
            return false;
        }

        public override Vector2 GetPlayerMovementDirection()
        {
			if(_joystick != null)
			{
				Vector2 output = _joystick.GetComponent<Joystick> ().currentOutput;
			//	Debug.Log (output);
				return output;
			}
			else
			{
				return Vector2.zero;				
			}

        }

		public void RequestBuildMobileUI()
		{
			UIEngine.BuildMobileControls ();
		}
    }
}