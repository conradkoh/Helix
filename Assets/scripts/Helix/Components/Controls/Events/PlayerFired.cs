using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helix.Components.Controls.Events
{
    public class PlayerFiredArgs : System.EventArgs
    {
        PlayerFiredArgs()
        {

        }
    }

    public delegate void PlayerFired(object sender,PlayerFiredArgs args);
}