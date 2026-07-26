using TMPro;
using UnityEngine;

public class BloodDisplay : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI text;

    [SerializeField] private PlayerStats playerstats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = playerstats.GetVampBlood().ToString();
    }
}
