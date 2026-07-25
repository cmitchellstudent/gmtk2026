using System;
using SupanthaPaul;
using UnityEngine;
using UnityEngine.Rendering;

public class playerAttackSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D attackHitbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableHitbox()
    {
        //Debug.Log("on");
        attackHitbox.enabled = true;
    }
    public void disableHitbox()
    {
        //Debug.Log("off");
        attackHitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.tag);
        if (other.gameObject.CompareTag("Koopa") || other.gameObject.CompareTag("FlyingEnemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
