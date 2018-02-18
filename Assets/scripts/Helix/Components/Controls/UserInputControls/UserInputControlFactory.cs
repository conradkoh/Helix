using System;
using Helix.Components.Controls.Configs;

namespace Helix.Components.Controls.UserInputControls
{
    public class UserInputControlFactory
    {
        public UserInputControlFactory()
        {
        }

        public static UserInputControl GetControls()
        {
            UserInputControl controls;
            switch (UserControlConfig.MODE)
            {
                case MODES.DESKTOP:
                    controls = new DesktopUserControl();
                    break;
                case MODES.MOBILE:
                    controls = new MobileUserControl();
                    break;
                default:
                    controls = null;
                    break;
            }
            return controls;
        }
    }
}