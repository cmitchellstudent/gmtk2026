using System;
using UnityEngine;

public class BloodWave : MonoBehaviour
{
    public float speed;
    public int height;
    private Vector2 pos;
    [SerializeField] private PlayerHealth playerHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object’s Y to the new calculated Y
        transform.position = new Vector2(transform.position.x, newY) ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHealth.TakeDamage(10);
    }
}
