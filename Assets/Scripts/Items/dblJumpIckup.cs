using System;
using UnityEngine;

public class dblJumpIckup : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerStats.hasDoubleJump)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerStats.hasDoubleJump = true;
        Destroy(gameObject);
    }
}
