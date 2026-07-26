using System.Collections;
using TMPro;
using UnityEngine;

public class DeathCountDown : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    public float maxSeconds => playerStats != null ? playerStats.GetTimeToLive() : 3f;
    private float timeleft;
    public TextMeshProUGUI UIText;
    [SerializeField] private PlayerHealth currentHealth; //call this to die
    public AudioSource alertSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeleft = maxSeconds;
        StartCoroutine(DecreaseTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (UIText != null)
            UIText.text = timeleft.ToString("00");
        if (timeleft <= 0 && currentHealth != null)
        {
            currentHealth.Die();
        }
    }
    private IEnumerator DecreaseTimer()
    {
        //Debug.Log(timeleft);
        if (timeleft <= 3) alertSound.Play();
        yield return new WaitForSeconds(1.0f);
        timeleft -= 1;
        StartCoroutine(DecreaseTimer());
    }

}
