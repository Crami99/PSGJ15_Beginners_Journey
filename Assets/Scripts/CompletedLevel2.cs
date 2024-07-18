using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletedLevel2 : MonoBehaviour
{
    private Text completedLevel2Text;
    private Text nextLevelText;
    private Text levelSelectorText;
    private Text restartText;
    private Text quitText;

    // Start is called before the first frame update
    void Start()
    {
        completedLevel2Text = GameObject.Find("Level2CompletedText").GetComponent<Text>();
        nextLevelText = GameObject.Find("NextLevelText").GetComponent<Text>();
        levelSelectorText = GameObject.Find("LevelSelectorText").GetComponent<Text>();
        restartText = GameObject.Find("RestartText").GetComponent<Text>();
        quitText = GameObject.Find("QuitText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        completedLevel2Text.text = "Level 2 completed!";
        completedLevel2Text.fontSize = 20;
        completedLevel2Text.alignment = TextAnchor.MiddleCenter;
        completedLevel2Text.color = new Color(0.0f, 1.0f, 0.0f); // Set this to a random color for now

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
        SceneManager.LoadScene("Level3");
    }
    public void PressLevelSelectorButton()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void PressRestartButton()
    {
        SceneManager.LoadScene("Level2");
    }

    public void PressQuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
