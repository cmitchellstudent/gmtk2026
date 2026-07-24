using System;
using UnityEngine;

public class healingItem : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int healAmount = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.IncreaseHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
