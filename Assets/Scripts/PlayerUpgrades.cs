using UnityEngine;

[CreateAssetMenu(fileName = "PlayerUpgrades", menuName = "Scriptable Objects/PlayerUpgrades")]
public class PlayerUpgrades : ScriptableObject
{
    [SerializeField] private float playerSpeed = 1f;
    [SerializeField] private float playerMaxHealth = 100f;
    
    public float PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }
}
