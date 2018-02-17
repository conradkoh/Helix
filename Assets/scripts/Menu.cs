using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	#region main menu (MM)
	public void MMPlayPressed()
	{
		SceneManager.LoadScene("loadout",LoadSceneMode.Single);
	}
	#endregion

	#region loadout menu (LM)
	public void LMConfirmPressed()
	{
		SceneManager.LoadScene("scene",LoadSceneMode.Single);
	}

	#endregion
}
