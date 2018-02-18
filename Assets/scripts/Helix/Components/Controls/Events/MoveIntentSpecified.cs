using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helix.Components.Controls.Events
{
    public class MoveIntentSpecifiedArgs : System.EventArgs
    {
        MoveIntentSpecifiedArgs()
        {

        }
    }

    public delegate void MoveIntentSpecified(object sender,MoveIntentSpecifiedArgs args);
}