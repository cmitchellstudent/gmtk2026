using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Object/PlayerStats")]
public class PlayerStats : ScriptableObject {
//All Public Player Stats Shown Here
    [SerializeField] private float playerSpeed = 1f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private int jumpAmount = 1; // double jump starts at 2
    [SerializeField] private float dashCooldown = 2f;
    [SerializeField] private float damageAmount = 2f;
    [SerializeField] private int vampBlood = 0; // currency for upgrades 
    
    // this mainly works because they have the same index when one gets removed or added
    [SerializeField] private List<int> skillList = new List<int>(); // contains the id of the skill the player has 
    [SerializeField] private List<int> skillLevel = new List<int>(); // containes the skill level of the skill at the same index in skillList
    
    // stat getters
    public float GetPlayerSpeed() => playerSpeed;
    public float getMaxHealth() => maxHealth;
    public float getJumpAmount() => jumpAmount;
    public float getDashCooldown() => dashCooldown;
    public float getVampBlood() => vampBlood;

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
        }

    }

}