using System;
using UnityEngine;

public class KoopaTurnZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Koopa"))
        {
            var koopaScript = other.GetComponent<KoopaEnemy>();
            koopaScript.Turn();
        }
    }
}
