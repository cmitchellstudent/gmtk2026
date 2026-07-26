using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseJumpAmount", menuName = "Scriptable Objects/Skills/IncreaseJumpAmount")]
public class IncreaseJumpAmountSkill : SkillData
{
    [SerializeField] private float upgradeJumpAmount = 5; // the amount of HP added to the player
    public override void Apply(PlayerStats stats) {
        // when selected player speed will be increased by set amount
        stats.SetStat(StatType.jumpAmount, stats.GetJumpAmount() + upgradeJumpAmount);
    }
}