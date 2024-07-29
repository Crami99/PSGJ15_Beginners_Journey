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
        
        gameOverText.text = "You Died!";
        gameOverText.fontSize = 20;
        gameOverText.alignment = TextAnchor.MiddleCenter;
        gameOverText.color = new Color(1.0f, 0.0f, 0.0f); // Set this to a random color for now

        restartText.text = "Restart";
        restartText.fontSize = 15;
        restartText.alignment = TextAnchor.MiddleCenter;
        restartText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        quitText.text = "Quit";
        quitText.fontSize = 15;
        quitText.alignment = TextAnchor.MiddleCenter;
        quitText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

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
