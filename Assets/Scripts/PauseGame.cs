using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] private Settings _settings;
    [SerializeField] private Slider audioSlider;

    [SerializeField] private Button shopButton;
    [SerializeField] private PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Pause();
        audioSlider.value = PlayerPrefs.GetFloat("Volume");
        Unpause();
    }

    void Start()
    {
        //audioSlider.value = _settings.GetVolume();
        shopButton.onClick.AddListener(playerHealth.Die);
        //audioSlider.onValueChanged.AddListener(_settings.SetVolume);
        pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        audioMixer.SetFloat("Volume", audioSlider.value);
        PlayerPrefs.SetFloat("Volume", audioSlider.value);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log(isPaused);
            if (isPaused)
            {
                Unpause();
            }
            else if(!isPaused)
            {
                Pause();
            }
        }
        
    }

    void Pause()
    {
        AudioListener.pause = true;
        isPaused = true;
        pauseCanvas.enabled = true;
        Time.timeScale = 0;
    }

    void Unpause()
    {
        AudioListener.pause = false;
        isPaused = false;
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
    }
}
