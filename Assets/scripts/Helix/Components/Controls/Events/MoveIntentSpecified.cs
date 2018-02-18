using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helix.Components.Controls.Events
{
    public class MoveIntentSpecifiedArgs : System.EventArgs
    {
        public Vector2 direction { get; set; }

        public MoveIntentSpecifiedArgs(Vector2 direction)
        {
            this.direction = direction;
        }
    }

    public delegate void MoveIntentSpecified(object sender,MoveIntentSpecifiedArgs args);
}