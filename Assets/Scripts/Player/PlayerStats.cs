using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject{
//All Public Player Stats Shown Hereuu
    [SerializeField] private float playerSpeed = 1f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private int jumpAmount = 1; // double jump starts at 2
    [SerializeField] private float dashCooldown =  0.2f;
    [SerializeField] private float damageAmount = 2f;
    [SerializeField] private int vampBlood = 0; // currency for upgrades 
    [SerializeField] private float timeToLive = 3f;
    
    // this mainly works because they have the same index when one gets removed or added
    [SerializeField] private List<int> skillList = new List<int>(); // contains the id of the skill the player has 
    [SerializeField] private List<int> skillLevel = new List<int>(); // containes the skill level of the skill at the same index in skillList
    
    // stat getters
    public float GetPlayerSpeed() => playerSpeed;
    public float GetMaxHealth() => maxHealth;
    public float GetJumpAmount() => jumpAmount;
    public float GetDashCooldown() => dashCooldown;
    public float GetVampBlood() => vampBlood;

    public float GetTimeToLive() => timeToLive; 

    // dynamic stat setter

    public void SetStat(StatType currStat, float val) 
    {
        switch(currStat)
        {
            case StatType.maxHealth:
                maxHealth = val;
                break;
            case StatType.speed:
                playerSpeed = val;
                break;
            case StatType.dashCooldown:
                dashCooldown = val;
                break;
            case StatType.jumpAmount:
                jumpAmount = (int)val;
                break;
            case StatType.damageAmount:
                damageAmount = val;
                break;
            case StatType.vampBlood:
                vampBlood = (int)val;
                break;
            case StatType.timeToLive:
                timeToLive = val;
                break;
        }

    }

    // Skill Methods

    public bool CanAfford(int cost) => vampBlood >= cost;

    public void SpendBlood(int vampBloodAmount) {
        if (CanAfford(vampBloodAmount))
        {
        vampBlood -= vampBloodAmount;
        }

        if (vampBlood < 0)
        {
            vampBlood = 0;
        }

    }

    public void GainBlood(int vampBloodAmount)
    {
        vampBlood += vampBloodAmount;
    }

     public int GetSkillLevel(int skillId)
    {
        int index = skillList.IndexOf(skillId);
        return index >= 0 ? skillLevel[index] : 0;
    }

    //setskill checks if the skill is already obtained and increases level if so
    public void SetSkill(int skillId, int level)
    {
        int index = skillList.IndexOf(skillId);
        if (index >= 0)
            skillLevel[index] = level;
        else // if skill hasent been obtained yet add the id to the list and its level.
        {
            skillList.Add(skillId);
            skillLevel.Add(level);
        }
    }

    public bool IsSkillMaxed(int skillId, int maxLevel)
    {
        return GetSkillLevel(skillId) >= maxLevel;
    }

}