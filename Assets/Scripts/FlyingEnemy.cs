using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
