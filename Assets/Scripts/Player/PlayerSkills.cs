using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public event EventHandler<OnSkillUnlockedEventArgs> OnSkillUnlocked;
    public class OnSkillUnlockedEventArgs : OnSkillUnlockedEventArgs{
        public SkillType skillType;
    }
    public enum SkillType{
        // put in ability names
        Dash, Dodge
    }

    private List<SkillType> unlockedSkillTypeList;
    public PlayerSkills(){
        unlockedSkillTypeList = new List<SkillType>();
    }

    public void UnlockSkill(SkillType skillType){
        unlockedSkillTypeList.Add(skillType);
        // alert event handler whenever skill is unlocked
        OnSkillUnlocked?.Invoke(this, new OnSkillUnlockedEventArgs{skillType = SkillType});
    }

    public bool IsSkillUnlocked(SkillType skillType){
        return unlockedSkillTypeList.Contains(skillType);
    }
}
