using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GameObject player;

    public int speed = 10;

    public int bossMaxHealth = 200;
    private int currentHealth;
    
    [SerializeField] private Slider BossHealthBar;
    //public BoxCollider2D collider;
    private Vector2 currVelocity;
    public PlayerHealth playerHealth; //script on player

    public int damageToPlayer = 10;

    private bool coroutineRunning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BossHealthBar.maxValue = bossMaxHealth;
        BossHealthBar.value = bossMaxHealth;
        currentHealth = bossMaxHealth;
        
        
        rb.linearVelocity = (Vector2.up + Vector2.right) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //storing vel to check if theyre stuck
        currVelocity = rb.linearVelocity;

        //flipping the sprite for facing its velocity
        if (rb.linearVelocity.x > 0f)
        {
            sr.flipX = false;
        } else if (rb.linearVelocity.x < 0f)
        {
            sr.flipX = true;
        }
        //clamping max velocity
        if (rb.linearVelocity.magnitude > speed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
        
        //if stuck, start moving
        if (rb.linearVelocity == Vector2.zero && !coroutineRunning)
        {
            coroutineRunning = true;
            StartCoroutine(startFlying());
        }
        
        BossHealthBar.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log(damage);
        currentHealth -= damage;
        rb.AddForce((GetVectorAwayFromPlayer()) * speed * 5, ForceMode2D.Impulse);
    }

    public Vector2 GetVectorAwayFromPlayer()
    {
        return (gameObject.transform.position - player.gameObject.transform.position).normalized;
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
        rb.linearVelocity = (GetVectorAwayFromPlayer()) * (speed * 5);
    }
}
