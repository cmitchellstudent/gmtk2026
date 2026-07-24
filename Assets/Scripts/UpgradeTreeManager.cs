using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeTreeManager : MonoBehaviour
{
    [SerializeField] private PlayerUpgrades playerUpgrades;
    public Button startButton;
    public Button speedUpButton;
    private TextMeshProUGUI speedUpButtonText;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartRun);
        speedUpButton.onClick.AddListener(UpgradePlayerSpeed);

        speedUpButtonText = speedUpButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerUpgrades.getSpeed >= 6)
        {
            speedUpButton.interactable = false;
            speedUpButtonText.text = "Upgrade Player Speed. Maxed!";
            
        }
        else
        {
            speedUpButtonText.text = "Upgrade Player Speed. Current: " + playerUpgrades.getSpeed.ToString();
        }
    }

    void StartRun()
    {
        SceneManager.LoadScene("Demo");
    }

    void UpgradePlayerSpeed()
    {
        if (playerUpgrades.getSpeed < 2)
        {
            playerUpgrades.setSpeed(3);
        } else if (playerUpgrades.getSpeed < 5)
        {
            playerUpgrades.setSpeed(6);
        } 
    }
}
