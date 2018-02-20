using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helix.Components.Controls.Events
{
	public class FaceIntentSpecifiedArgs : System.EventArgs
	{
		public Quaternion direction { get; set; }

		public FaceIntentSpecifiedArgs (Quaternion direction)
		{
			this.direction = direction;
			//To debug inputs and movement intent:
			//Debug.Log ("Moving in direction: " + direction.ToString());
		}
	}

	public delegate void FaceIntentSpecified (object sender, FaceIntentSpecifiedArgs args);
}