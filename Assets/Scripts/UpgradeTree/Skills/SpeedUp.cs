using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUp", menuName = "Scriptable Objects/Skills/SpeedUp")]
public class SpeedUpSkill : SkillData
{
    [SerializeField] private float upgradeSpeedAmount = 1f; // the amount of speed added to the player
    public override void Apply(PlayerStats stats) {
        // when selected player speed will be increased by set amount
        stats.SetStat(StatType.speed, stats.GetPlayerSpeed() + upgradeSpeedAmount);
    }
}