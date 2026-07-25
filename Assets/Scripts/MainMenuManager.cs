using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public PlayerStats playerStats;
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

    // on new game set player stats to default
    void NewGame()
    {
        playerStats.SetStat(StatType.speed, 1);
        playerStats.SetStat(StatType.maxHealth, 10);
        SceneManager.LoadScene("Demo");
    }

    void Exit()
    {
        Application.Quit();
    }
}
