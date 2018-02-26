using System;
using UnityEngine;

namespace Helix.Components.Controls.UserInputControls
{
    public class DesktopUserControl: UserInputControl
    {

        public Vector2 firingInitialDirection = Vector2.zero;
        public bool isFiring = false;

        public DesktopUserControl()
        {
            
        }

        public override void InitControls()
        {
            
        }

        public override bool ShouldPlayerFire()
        {
            return isFiring;
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
            //follow walking direction
            Vector2 directionVector = GetPlayerMovementDirection();
            float output = Mathf.Rad2Deg * Mathf.Atan2(directionVector.x, directionVector.y);
            return Quaternion.Euler(0, output, 0);            	
        }

        public override Quaternion GetPlayerAimDirection()
        {
            Vector2 mousePosition = Input.mousePosition;

            if (isFiring)
            {
                //follow mouse
                Vector2 directionVector = mousePosition - firingInitialDirection;
                float output = Mathf.Rad2Deg * Mathf.Atan2(directionVector.x, directionVector.y);
                return Quaternion.Euler(0, output, 0);

            }
            else
            {
                return Quaternion.identity;
            }               
        }



        public override void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isFiring) //start face control
            {
                isFiring = true;
                firingInitialDirection = Input.mousePosition;


                //spawn reference point
                UIEngine.SpawnTether();
            }

            if (Input.GetMouseButton(0) && isFiring)
            {
                UIEngine.UpdateTether(firingInitialDirection, Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0) && isFiring) //end face control
            {
                isFiring = false;
                firingInitialDirection = Vector2.zero;

                UIEngine.HideTether();
            }
        }

        public override void RequestBuildUI()
        {
            UIEngine.BuildDesktopControls();
        }
    }
}