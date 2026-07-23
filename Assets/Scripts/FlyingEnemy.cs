using System;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public int speed = 10;

    public BoxCollider2D collider;
    private Vector2 currVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = (Vector2.up + Vector2.right) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        currVelocity = rb.linearVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        var normal = collision.contacts[0].normal;
        Vector2 reflection = Vector2.Reflect(currVelocity, normal);
        rb.linearVelocity = reflection;
    }
}
