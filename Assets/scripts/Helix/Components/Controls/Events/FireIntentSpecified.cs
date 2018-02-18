using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helix.Components.Controls.Events
{
    public class FireIntentSpecifiedArgs : System.EventArgs
    {
        FireIntentSpecifiedArgs()
        {

        }
    }

    public delegate void FireIntentSpecified(object sender,FireIntentSpecifiedArgs args);
}