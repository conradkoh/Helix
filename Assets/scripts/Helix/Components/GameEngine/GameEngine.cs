using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Controllers;

namespace Helix.Components.GameEngine
{
	public class GameEngine : MonoBehaviour
	{
		private User _user;
		private static GameEngine _instance;

		void Awake ()
		{
			if (GameEngine._instance == null) {
				GameEngine._instance = this;
			}
		}

		void Start ()
		{
			this._user = gameObject.AddComponent<User> (); //Instantiate the user
		}

		// Update is called once per frame
		void Update ()
		{
		}

		public static GameEngine GetInstance ()
		{
			return GameEngine._instance;
		}

	}
}