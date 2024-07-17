using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverLevel1 : MonoBehaviour
{
    private Text gameOverLevel1Text;
    private Text levelSelectorText;
    private Text restartText;
    private Text quitText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverLevel1Text = GameObject.Find("GameOverLevel1Text").GetComponent<Text>();
        levelSelectorText = GameObject.Find("LevelSelectorText").GetComponent<Text>();
        restartText = GameObject.Find("RestartText").GetComponent<Text>();
        quitText = GameObject.Find("QuitText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gameOverLevel1Text.text = "Level 1 failed!";
        gameOverLevel1Text.fontSize = 20;
        gameOverLevel1Text.alignment = TextAnchor.MiddleCenter;
        gameOverLevel1Text.color = new Color(1.0f, 0.0f, 0.0f); // Set this to a random color for now

        levelSelectorText.text = "Select Level";
        levelSelectorText.fontSize = 15;
        levelSelectorText.alignment = TextAnchor.MiddleCenter;
        levelSelectorText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        restartText.text = "Restart";
        restartText.fontSize = 15;
        restartText.alignment = TextAnchor.MiddleCenter;
        restartText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        quitText.text = "Quit";
        quitText.fontSize = 15;
        quitText.alignment = TextAnchor.MiddleCenter;
        quitText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now
    }
    public void PressLevelSelectorButton()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void PressRestartButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PressQuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
