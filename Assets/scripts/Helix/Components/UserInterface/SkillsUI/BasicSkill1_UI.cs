using System.Collections;
using System.Collections.Generic;
using Helix.Components.Skills;
using Helix.Components.Skills.Events;
using Helix.Components.UserInterface.SkillsUI;
using UnityEngine;

public class BasicSkill1_UI : MonoBehaviour, ISkillsUI
{

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    //This should just take care of the UI portion of the skill fired function
    public void SkillFired(object sender, SkillFiredArgs args)
    {
        Debug.Log("Basic Skill 1 firing through UI!");
    }
}
