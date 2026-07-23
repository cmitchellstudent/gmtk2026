using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public PlayerUpgrades playerUpgrades;
    public Button ExitButton;
    public Button StartButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartButton.onClick.AddListener(NewGame);
        ExitButton.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewGame()
    {
        playerUpgrades.setSpeed(1);
        playerUpgrades.setMaxHealth(10);
        SceneManager.LoadScene("Demo");
    }

    void Exit()
    {
        Application.Quit();
    }
}
