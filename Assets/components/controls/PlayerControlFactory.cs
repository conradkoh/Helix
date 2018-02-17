using System;

public class PlayerControlFactory
{
	public PlayerControlFactory ()
	{
	}

	public static IPlayerControl GetControls ()
	{
		IPlayerControl controls;
		switch (PlayerControlConfig.MODE) {
		case MODES.DESKTOP:
			controls = new DesktopPlayerControl ();
			break;
		case MODES.MOBILE:
			controls = new MobilePlayerControl ();
			break;
		default:
			controls = null;
			break;
		}
		return controls;
	}
}