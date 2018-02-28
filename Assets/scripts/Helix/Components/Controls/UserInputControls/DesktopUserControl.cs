using System;
using UnityEngine;
using Helix.Components.Skills;

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

        public override void Update()
        {
            #region movement
            Vector2 moveDirection = new Vector2(0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += new Vector2(0, 1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection += new Vector2(-1, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection += new Vector2(0, -1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection += new Vector2(1, 0);
            }                
                
            if (this.DidIntendMove != null)
            {
                this.DidIntendMove(moveDirection.normalized);
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                if (this.DidIntendMoveEnd != null)
                {
                    this.DidIntendMoveEnd(Vector2.zero);
                }
            }

            #endregion

            #region casting skills (mouse)
            //
            //click and drag mechanics
            //
            if (Input.GetMouseButtonDown(0) && !isFiring) //start fire control
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

            if (Input.GetMouseButtonUp(0) && isFiring) //end fire control
            {
                isFiring = false;
                firingInitialDirection = Vector2.zero;

                //hide reference point
                UIEngine.HideTether();
            }

            if (isFiring)
            {
                //follow mouse
                Vector2 directionVector = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - firingInitialDirection;
                float output = Mathf.Rad2Deg * Mathf.Atan2(directionVector.x, directionVector.y);

                if (this.DidIntendCast != null)
                {
                    this.DidIntendCast(SkillType.primary, Quaternion.Euler(0, output, 0));
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

            #region casting skills (key)
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                this.DidIntendCast(SkillType.attackSkillPrimary, Quaternion.identity); //direction for skill cast not implemented yet
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                this.DidIntendCast(SkillType.attackSkillSecondary, Quaternion.identity); //direction for skill cast not implemented yet
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                this.DidIntendCast(SkillType.moveSkillPrimary, Quaternion.identity); //direction for skill cast not implemented yet
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                this.DidIntendCast(SkillType.moveSkillSecondary, Quaternion.identity); //direction for skill cast not implemented yet
            }
            #endregion
        }

        public override void RequestBuildUI()
        {
            UIEngine.BuildDesktopControls();
        }
    }
}