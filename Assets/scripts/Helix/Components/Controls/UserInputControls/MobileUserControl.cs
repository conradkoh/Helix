using System;
using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
    public class MobileUserControl:UserInputControl
    {
        public GameObject moveJoystick;
        public GameObject fireJoystick;

        public MobileUserControl()
        {
            //event subscriptions
            Main.ShouldInitControls += InitControls;
            UIEngine.ShouldBuildUI += RequestBuildMobileUI;
        }

        public void InitControls()
        {
            this.moveJoystick = UIEngine.GetInstance().GetMoveJoystick();
            this.fireJoystick = UIEngine.GetInstance().GetFireJoystick();
        }

        public override bool ShouldPlayerFire()
        {
            return fireJoystick.GetComponent<Joystick>().isActive;
        }

        public override Vector2 GetPlayerMovementDirection()
        {
            if (moveJoystick != null)
            {
                Joystick js = moveJoystick.GetComponent<Joystick>();

                if (js.isActive)
                {
                    return js.eightPointOutput;
                }
                else
                {
                    return Vector2.zero;				
                }
            }
            else
            {
                return Vector2.zero;				
            }

        }

        public override bool GetPlayerShouldMove()
        {
            return moveJoystick.GetComponent<Joystick>().isActive;
        }

        public override Quaternion GetPlayerFaceDirection()
        {

            Joystick faceJS = fireJoystick.GetComponent<Joystick>();
            Joystick moveJS = moveJoystick.GetComponent<Joystick>();


            if (fireJoystick != null && moveJoystick != null)
            {

                /// <summary>
                /// If face joystick is not moving, face direction follows movement
                /// </summary>
                if (faceJS.isActive)
                {
                    float faceOutput = faceJS.outputAngle;
                    return Quaternion.Euler(0, faceOutput, 0);
                }
                else
                {
                    Vector2 moveOutput = moveJS.eightPointOutput;
                    float outputAngle = Mathf.Rad2Deg * Mathf.Atan2(moveOutput.x, moveOutput.y);
                    return Quaternion.Euler(0, outputAngle, 0);
                }					
            }
            else
            {
                return Quaternion.identity;				
            }
        }

        public override Quaternion GetPlayerAimDirection()
        {
            return Quaternion.Euler(0, fireJoystick.GetComponent<Joystick>().outputAngle, 0);
        }

        //		public override bool GetPlayerShouldFace()
        //		{
        //			return fireJoystick.GetComponent<Joystick>().isActive || moveJoystick.GetComponent<Joystick>().isActive;
        //			;
        //		}
        //
        public override void Update()
        {

        }

        public void RequestBuildMobileUI()
        {
            UIEngine.BuildMobileControls();
        }
    }
}