using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeTreeManager : MonoBehaviour
{
    public Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartRun);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartRun()
    {
        SceneManager.LoadScene("Demo");
    }
}
