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
