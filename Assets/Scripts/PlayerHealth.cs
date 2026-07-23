using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public Slider healthSlider;
    public Image invincibleIcon;
    [HideInInspector]public int currentHealth;
    
    private bool isInvincible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isInvincible = false;
        invincibleIcon.enabled = false;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            invincibleIcon.enabled = true;
        }
        else if (!isInvincible)
        {
            invincibleIcon.enabled = false;
        }
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
        if (!isInvincible)
        {
            currentHealth -= amount;
            if (currentHealth <= 0) currentHealth = 0;
            isInvincible = true;
            StartCoroutine(InvincibleFrames());
        }
        
    }

    public void Die()
    {
        SceneManager.LoadScene("UpgradeTree");
    }

    private IEnumerator InvincibleFrames()
    {
        yield return new WaitForSeconds(1.0f);
        isInvincible = false;
    }
}
