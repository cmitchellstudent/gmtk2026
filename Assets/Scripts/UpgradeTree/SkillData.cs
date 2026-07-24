using System.Collections.Generic;
using UnityEngine;

public abstract class SkillData : ScriptableObject
{
    public string skillId;
    public string skillName;
    [TextArea(2, 4)]
    public string skillDescription;
    public int vampBloodCost = 1;
    public Sprite icon;
    public int maxLevel = 1;
    public List<string> unlockedSkillIds = new List<string>(); // skills that become visible when this skill is upgraded

    public abstract void Apply(PlayerStats stats);
}