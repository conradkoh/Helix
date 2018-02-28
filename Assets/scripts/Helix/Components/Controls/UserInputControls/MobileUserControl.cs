using System;
using UnityEngine;
using Helix.Components.Skills;

namespace Helix.Components.Controls.UserInputControls
{
    public class MobileUserControl:UserInputControl
    {
        public GameObject moveJoystick;
        public GameObject fireJoystick;

        public MobileUserControl()
        {
            //event subscriptions
        }

        public override void InitControls()
        {
            this.moveJoystick = UIEngine.GetInstance().GetMoveJoystick();
            this.fireJoystick = UIEngine.GetInstance().GetFireJoystick();
        }

        public override void Update()
        {
            #region move 
            Joystick moveJoystickComponent = moveJoystick.GetComponent<Joystick>();
            if (moveJoystickComponent.isActive)
            {
                if (this.DidIntendMove != null)
                {
                    this.DidIntendMove(moveJoystickComponent.GetEightPointOutput());
                }
            }
            else
            {
                if (this.DidIntendMoveEnd != null)
                {
                    this.DidIntendMoveEnd(Vector2.zero);
                }
            }

            #endregion

            #region cast (joystick)
            Joystick castJoystickComponent = fireJoystick.GetComponent<Joystick>();
            if (castJoystickComponent.isActive)
            {
                if (this.DidIntendCast != null)
                {
                    this.DidIntendCast(SkillType.primary, Quaternion.Euler(0, castJoystickComponent.GetOutputAngle(), 0));
                }
            }
            else
            {
                if (this.DidIntendCastEnd != null)
                {
                    this.DidIntendCastEnd(SkillType.primary, Quaternion.identity);
                }
            }
            #endregion 

            #region cast (button)

            #endregion


        }

        public override void RequestBuildUI()
        {
            UIEngine.BuildMobileControls();
        }
    }
}