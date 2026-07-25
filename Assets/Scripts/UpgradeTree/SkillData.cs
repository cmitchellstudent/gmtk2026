using System.Collections.Generic;
using UnityEngine;

//skill attributes get set in its scene asset
public abstract class SkillData : ScriptableObject
{
    public int skillId;
    public string skillName;
    [TextArea(2, 4)]
    public string skillDescription;
    public int vampBloodCost;
    public Sprite icon;
    public int maxLevel;
    public List<string> unlockedSkillIds = new List<string>(); // skills that become visible when this skill is upgraded

    // used by skills to mutate the player
    public abstract void Apply(PlayerStats stats);
}