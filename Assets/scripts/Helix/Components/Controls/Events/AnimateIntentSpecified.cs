using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helix.Components.Controls.Events
{
    public class AnimateIntentSpecifiedArgs : System.EventArgs
    {
        public AnimateState state { get; set; }

        public Quaternion direction { get; set; }

        public AnimateIntentSpecifiedArgs(AnimateState state, Quaternion direction)
        {
            this.state = state;   
            this.direction = direction;
        }
    }

    public delegate void AnimateIntentSpecified(object sender,AnimateIntentSpecifiedArgs args);

    public enum AnimateState
    {
        Forward,
        BackwardAndAttack,
        None
    }
}