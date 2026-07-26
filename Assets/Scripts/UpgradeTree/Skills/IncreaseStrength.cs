using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseStrength", menuName = "Scriptable Objects/Skills/IncreaseStrength")]
public class IncreaseStrengthSkill : SkillData
{
    [SerializeField] private float upgradeStrengthAmount = 1f; // the amount of speed added to the player
    public override void Apply(PlayerStats stats) {
        // when selected player speed will be increased by set amount
        stats.SetStat(StatType.attackPower, stats.GetAttackPower() + upgradeStrengthAmount);
    }
}