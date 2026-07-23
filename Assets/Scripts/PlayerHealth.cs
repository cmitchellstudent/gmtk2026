using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [HideInInspector]public int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) Die();
    }

    void increaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public void decreaseHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) currentHealth = 0;
    }

    public void Die()
    {
        SceneManager.LoadScene("UpgradeTree");
    }
}
