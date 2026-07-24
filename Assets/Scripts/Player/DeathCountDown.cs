using System.Collections;
using TMPro;
using UnityEngine;

public class DeathCountDown : MonoBehaviour
{
    public float maxSeconds = 3;
    private float timeleft = 3;
    public TextMeshProUGUI UIText;
    public PlayerHealth currentHealth; //call this to die
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeleft = maxSeconds;
        StartCoroutine(DecreaseTimer());
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = timeleft.ToString("00");
        if (timeleft <= 0)
        {
            currentHealth.Die();
        }
    }
    private IEnumerator DecreaseTimer()
    {
        //Debug.Log(timeleft);
        yield return new WaitForSeconds(1.0f); 
        timeleft-= 1;
        StartCoroutine(DecreaseTimer());
    }
    
}
