using System;
using UnityEngine;

public class KoopaEnemy : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    public float speed;

    public int damageToPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.right * speed;
    }

    public void Turn()
    {
        speed *= -1;
        if (sr.flipX)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damageToPlayer);
        }
    }
}
