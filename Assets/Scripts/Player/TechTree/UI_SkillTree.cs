using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillTree : MonoBehaviour
{
    private PlayerSkills playerSkills;

    private void Awake(){
        // add for each button on tech tree
        this.transform.Find("TechSkillBtn").GetComponent<Button_UI>().ClickFunc = () => {
            //playerSkills.UnlockSkill(PlayerSkills.SkillType.)
        };
    }

    public void SetPlayerSkills(PlayerSkills playerSkills){
        this.playerSkills = playerSkills;
    }
}
