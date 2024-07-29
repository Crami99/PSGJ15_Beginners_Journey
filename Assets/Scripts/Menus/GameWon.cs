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
        
        gameWonText.text = "You Escaped!";
        gameWonText.fontSize = 20;
        gameWonText.alignment = TextAnchor.MiddleCenter;
        gameWonText.color = new Color(1.0f, 0.0f, 0.0f); // Set this to a random color for now

        restartText.text = "Restart";
        restartText.fontSize = 15;
        restartText.alignment = TextAnchor.MiddleCenter;
        restartText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        quitText.text = "Quit";
        quitText.fontSize = 15;
        quitText.alignment = TextAnchor.MiddleCenter;
        quitText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now
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
