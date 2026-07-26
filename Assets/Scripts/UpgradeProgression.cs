using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeProgression", menuName = "Scriptable Objects/UpgradeProgression")]
public class UpgradeProgression : ScriptableObject
{
    public bool unlockedTimerUpgrade = true;
    public bool unlockedSpeedUpgrade;
    public bool unlockedStrengthUpgrade;
    public bool unlockedHealthUpgrade;
    
}
