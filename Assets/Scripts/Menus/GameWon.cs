using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    PlayerStatus status;

    private Text gameWonText;
    private Text restartText;
    private Text quitText;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();

        gameWonText = GameObject.Find("GameWonText").GetComponent<Text>();
        restartText = GameObject.Find("RestartText").GetComponent<Text>();
        quitText = GameObject.Find("QuitText").GetComponent<Text>();
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
