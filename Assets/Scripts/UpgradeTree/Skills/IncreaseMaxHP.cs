using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseMaxHP", menuName = "Scriptable Objects/Skills/IncreaseMaxHP")]
public class IncreaseMaxHpSkill : SkillData
{
    [SerializeField] private float upgradeHPAmount = 5; // the amount of HP added to the player
    public override void Apply(PlayerStats stats) {
        // when selected player speed will be increased by set amount
        stats.SetStat(StatType.maxHealth, stats.GetMaxHealth() + upgradeHPAmount);
    }
}