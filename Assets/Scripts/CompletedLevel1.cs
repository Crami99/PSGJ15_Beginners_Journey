using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletedLevel1 : MonoBehaviour
{
    private Text completedLevel1Text;
    private Text nextLevelText;
    private Text levelSelectorText;
    private Text restartText;
    private Text quitText;

    // Start is called before the first frame update
    void Start()
    {
        completedLevel1Text = GameObject.Find("Level1CompletedText").GetComponent<Text>();
        nextLevelText = GameObject.Find("NextLevelText").GetComponent<Text>();
        levelSelectorText = GameObject.Find("LevelSelectorText").GetComponent<Text>();
        restartText = GameObject.Find("RestartText").GetComponent<Text>();
        quitText = GameObject.Find("QuitText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        completedLevel1Text.text = "Level 1 completed!";
        completedLevel1Text.fontSize = 20;
        completedLevel1Text.alignment = TextAnchor.MiddleCenter;
        completedLevel1Text.color = new Color(0.0f, 1.0f, 0.0f); // Set this to a random color for now

        nextLevelText.text = "Next Level";
        nextLevelText.fontSize = 15;
        nextLevelText.alignment = TextAnchor.MiddleCenter;
        nextLevelText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

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

    public void PressNextLevelButton()
    {
        SceneManager.LoadScene("Level2");
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
