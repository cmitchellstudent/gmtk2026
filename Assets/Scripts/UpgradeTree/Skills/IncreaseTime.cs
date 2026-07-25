
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseTime", menuName = "Scriptable Objects/Skills/IncreaseTime")]
public class IncreaseTimeSkill : SkillData
{
    [SerializeField] private float upgradeTimeAmount = 1f; // the amount of speed added to the player
    public override void Apply(PlayerStats stats) {
        // when selected player speed will be increased by set amount
        stats.SetStat(StatType.timeToLive, stats.GetTimeToLive() + upgradeTimeAmount);
    }
}