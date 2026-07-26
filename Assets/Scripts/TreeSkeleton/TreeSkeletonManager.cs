using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TreeSkeletonManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TextMeshProUGUI bloodText;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button buyButton;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        bloodText.text = playerStats.GetVampBlood().ToString();
    }

    public void writeToPanel(string text)
    {
        panelText.text = text;
    }

    void StartGame()
    {
        SceneManager.LoadScene("Demo");
    }
}
