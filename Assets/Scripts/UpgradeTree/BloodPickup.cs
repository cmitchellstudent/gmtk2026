using System;
using UnityEngine;

public class BloodPickup : MonoBehaviour
{
    private BoxCollider2D collider;
    [SerializeField] private PlayerStats playerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.GainBlood(1);
            Destroy(gameObject);
        }
    }
}
