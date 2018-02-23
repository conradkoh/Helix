using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helix.Components.Controls.Events
{
    public class FireIntentSpecifiedArgs : System.EventArgs
    {
        public Quaternion direction { get; set; }

        public FireIntentSpecifiedArgs(Quaternion direction)
        {
            this.direction = direction;
        }
    }

    public delegate void FireIntentSpecified(object sender,FireIntentSpecifiedArgs args);
}