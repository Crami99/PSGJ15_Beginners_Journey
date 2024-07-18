using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MainMenuScript : MonoBehaviour
{
    private Text mainMenuText;
    private Text playText;
    private Text howToPlayText;
    private Text levelSelectorText;
    private Text optionsText;
    private Text creditsText;

    public static bool completedLevel1;
    public static bool completedLevel2;

    private void Start()
    {
        mainMenuText = GameObject.Find("MainMenuText").GetComponent<Text>();
        playText = GameObject.Find("PlayText").GetComponent<Text>();
        howToPlayText = GameObject.Find("HowToPlayText").GetComponent<Text>();
        levelSelectorText = GameObject.Find("LevelSelectorText").GetComponent<Text>();
        optionsText = GameObject.Find("OptionsText").GetComponent<Text>();
        creditsText = GameObject.Find("CreditsText").GetComponent<Text>();
    }

    private void Update()
    {
        mainMenuText.text = "Main Menu";
        mainMenuText.fontSize = 20;
        mainMenuText.alignment = TextAnchor.MiddleCenter;
        mainMenuText.color = new Color(0.5f, 0.8f, 0.0f); // Set this to a random color for now

        playText.text = "Play";
        playText.fontSize = 15;
        playText.alignment = TextAnchor.MiddleCenter;
        playText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        howToPlayText.text = "How to Play";
        howToPlayText.fontSize = 15;
        howToPlayText.alignment = TextAnchor.MiddleCenter;
        howToPlayText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        levelSelectorText.text = "Level Select";
        levelSelectorText.fontSize = 15;
        levelSelectorText.alignment = TextAnchor.MiddleCenter;
        levelSelectorText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        optionsText.text = "Options";
        optionsText.fontSize = 15;
        optionsText.alignment = TextAnchor.MiddleCenter;
        optionsText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        creditsText.text = "Credits";
        creditsText.fontSize = 15;
        creditsText.alignment = TextAnchor.MiddleCenter;
        creditsText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        // If the player didn't complete Level 1, set it to false
        if (completedLevel1 == false)
        {
            completedLevel1 = false;
        }

        // Else if the player completed Level 1, set it to true
        else if (completedLevel1 == true)
        {
            completedLevel1 = true;
        }

        // If the player didn't complete Level 2, set it to false
        if (completedLevel2 == false)
        {
            completedLevel2 = false;
        }

        // Else if the player completed Level 2, set it to true
        else if (completedLevel2 == true)
        {
            completedLevel2 = true;
        }
    }

    public void PressPlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PressHowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void PressLevelSelectorButton()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void PressOptionsButton()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void PressCreditsButton()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
}
