using UnityEngine;

public class WallJumpPickup : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerStats.hasWallJump)
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
        playerStats.hasWallJump = true;
        Destroy(gameObject);
    }
}
