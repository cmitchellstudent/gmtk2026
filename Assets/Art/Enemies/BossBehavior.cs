using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public int speed = 10;
    public int damageToPlayer = 10;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    private Vector2 currVelocity;
    public PlayerHealth playerHealth;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = (Vector2.up + Vector2.right) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (currVelocity.x > 0)
        {
            sr.flipX = false;
        } else if (currVelocity.x < 0)
            sr.flipX = true;
        
        currVelocity = rb.linearVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damageToPlayer);
        }
        //Debug.Log(collision.gameObject.name);
        var normal = collision.contacts[0].normal;
        Vector2 reflection = Vector2.Reflect(currVelocity, normal);
        rb.linearVelocity = reflection;
    }
}
