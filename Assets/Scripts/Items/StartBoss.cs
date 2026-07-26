using System;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    public GameObject[] thingsToEnable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject thing in thingsToEnable)
        {
            thing.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enableThings()
    {
        foreach (GameObject thing in thingsToEnable)
        {
            thing.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enableThings();
        }
    }
}
