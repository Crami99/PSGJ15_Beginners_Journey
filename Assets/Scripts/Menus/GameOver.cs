using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    PlayerStatus status;
    private Text gameOverText;
    private Text restartText;
    private Text quitText;

    private AudioSource playerDeathSound;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();

        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        restartText = GameObject.Find("RestartText").GetComponent<Text>();
        quitText = GameObject.Find("QuitText").GetComponent<Text>();

        playerDeathSound = GetComponent<AudioSource>();

        playerDeathSound.volume = PlayerPrefs.GetFloat("SFXSliderValue", 100f);
        playerDeathSound.clip = Resources.Load<AudioClip>("SoundEffects/Player/player death");

        playerDeathSound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    
    public void PressRestartButton()
    {
        status.Restart();
        status.NextRoom();

        PlayerStatus.buttonPressSound.Play();
    }

    public void PressQuitButton()
    {
        status.ResetStats();
        SceneManager.LoadScene("MainMenu");

        PlayerStatus.buttonPressSound.Play();
    }
}
