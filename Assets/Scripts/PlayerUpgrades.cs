using UnityEngine;

[CreateAssetMenu(fileName = "PlayerUpgrades", menuName = "Scriptable Objects/PlayerUpgrades")]
public class PlayerUpgrades : ScriptableObject
{
    [SerializeField] private float playerSpeed = 1f;
    [SerializeField] private float playerMaxHealth = 100f;
    
    public float getSpeed => playerSpeed;

    public void setSpeed(float val)
    {
        playerSpeed = val;
    }
    public float getMaxHealth => playerMaxHealth;

    public void setMaxHealth(float val)
    {
        playerMaxHealth = val;
    }
}
