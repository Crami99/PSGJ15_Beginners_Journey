using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenuScript : MonoBehaviour
{
    PlayerStatus status;

    private Text playText;
    private Text howToPlayText;
    private Text levelSelectorText;
    private Text optionsText;
    private Text creditsText;

    // Reference to the main menu animated video object
    private VideoPlayer mainMenuAnimatedVideo;

    private void Start()
    {
        status = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();

        playText = GameObject.Find("PlayText").GetComponent<Text>();
        howToPlayText = GameObject.Find("HowToPlayText").GetComponent<Text>();
        optionsText = GameObject.Find("OptionsText").GetComponent<Text>();
        creditsText = GameObject.Find("CreditsText").GetComponent<Text>();

        mainMenuAnimatedVideo = GameObject.Find("MainMenuAnimatedVideo").GetComponent<VideoPlayer>();

        // Find the main menu animated video video URL at the StreamingAssets path
        mainMenuAnimatedVideo.url = System.IO.Path.Combine(Application.streamingAssetsPath, "start1.mp4");

        // Make sure the main menu animated video keeps looping after it's done playing
        mainMenuAnimatedVideo.isLooping = true;
        mainMenuAnimatedVideo.Play();

        playText.text = "Play";
        playText.fontSize = 15;
        playText.alignment = TextAnchor.MiddleCenter;
        playText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        howToPlayText.text = "How to Play";
        howToPlayText.fontSize = 15;
        howToPlayText.alignment = TextAnchor.MiddleCenter;
        howToPlayText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        optionsText.text = "Options";
        optionsText.fontSize = 15;
        optionsText.alignment = TextAnchor.MiddleCenter;
        optionsText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        creditsText.text = "Credits";
        creditsText.fontSize = 15;
        creditsText.alignment = TextAnchor.MiddleCenter;
        creditsText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now
    }

    private void Update()
    {

    }

    public void PressPlayButton()
    {
        PlayerStatus.buttonPressSound.Play();
        
        status.Restart();
        status.NextRoom();
    }

    public void PressHowToPlayButton()
    {
        PlayerStatus.buttonPressSound.Play();
        SceneManager.LoadScene("HowToPlay");
    }
    
    public void PressOptionsButton()
    {   
        PlayerStatus.buttonPressSound.Play();
        SceneManager.LoadScene("OptionsMenu");
    }

    public void PressCreditsButton()
    {   
        PlayerStatus.buttonPressSound.Play();
        SceneManager.LoadScene("CreditsMenu");
    }
}
