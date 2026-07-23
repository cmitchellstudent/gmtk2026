using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public Slider healthSlider;
    [HideInInspector]public int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
        if (currentHealth <= 0) Die();
    }

    void increaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) currentHealth = 0;
    }

    public void Die()
    {
        SceneManager.LoadScene("UpgradeTree");
    }
}
