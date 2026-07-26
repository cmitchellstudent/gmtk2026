using System.Collections;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public int speed = 10;

    //public BoxCollider2D collider;
    private Vector2 currVelocity;
    public PlayerHealth playerHealth; //script on player

    public int damageToPlayer = 10;

    private bool coroutineRunning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = (Vector2.up + Vector2.right) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        currVelocity = rb.linearVelocity;

        if (rb.linearVelocity.x > 0f)
        {
            sr.flipX = false;
        } else if (rb.linearVelocity.x < 0f)
        {
            sr.flipX = true;
        }
        
        if (rb.linearVelocity == Vector2.zero && !coroutineRunning)
        {
            coroutineRunning = true;
            StartCoroutine(startFlying());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damageToPlayer);
        }
        //Debug.Log(collision.gameObject.name);
        var normal = collision.contacts[0].normal;
        Vector2 reflection = Vector2.Reflect(currVelocity, normal);
        rb.linearVelocity = reflection;
    }

    private IEnumerator startFlying()
    {
        yield return new WaitForSeconds(3.0f);
        coroutineRunning = false;
        rb.linearVelocity = (Vector2.up + Vector2.right) * speed;
        
    }
}
