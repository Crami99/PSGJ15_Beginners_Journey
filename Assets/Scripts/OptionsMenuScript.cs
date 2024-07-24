using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenuScript : MonoBehaviour
{
    private Text optionsText;
    private Text backText;
    private Text musicVolumeText;
    private Text sfxVolumeText;

    private Slider musicVolumeSlider;
    public static Slider sfxVolumeSlider;

    private Text musicVolumeSliderText;
    private Text sfxVolumeSliderText;

    // Start is called before the first frame update
    void Start()
    {
        optionsText = GameObject.Find("OptionsText").GetComponent<Text>();
        backText = GameObject.Find("BackText").GetComponent<Text>();
        musicVolumeText = GameObject.Find("MusicVolumeText").GetComponent<Text>();
        sfxVolumeText = GameObject.Find("SFXVolumeText").GetComponent<Text>();

        musicVolumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
        sfxVolumeSlider = GameObject.Find("SFXVolumeSlider").GetComponent<Slider>();

        // Load the music and sfx volume slider values at start
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicSliderValue");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXSliderValue");

        musicVolumeSliderText = GameObject.Find("MusicVolumeSliderText").GetComponent<Text>();
        sfxVolumeSliderText = GameObject.Find("SFXVolumeSliderText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        optionsText.text = "Options";
        optionsText.fontSize = 20;
        optionsText.alignment = TextAnchor.MiddleCenter;
        optionsText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        backText.text = "Back";
        backText.fontSize = 15;
        backText.alignment = TextAnchor.MiddleCenter;
        backText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        musicVolumeText.text = "Music Volume";
        musicVolumeText.fontSize = 15;
        musicVolumeText.alignment = TextAnchor.MiddleRight;
        musicVolumeText.color = new Color(1.0f, 1.0f, 1.0f); // Set this to a random color for now

        sfxVolumeText.text = "SFX Volume";
        sfxVolumeText.fontSize = 15;
        sfxVolumeText.alignment = TextAnchor.MiddleRight;
        sfxVolumeText.color = new Color(1.0f, 1.0f, 1.0f); // Set this to a random color for now

        musicVolumeSliderText.text = Mathf.RoundToInt(musicVolumeSlider.value).ToString() + "%";
        musicVolumeSliderText.fontSize = 15;
        musicVolumeSliderText.alignment = TextAnchor.MiddleLeft;
        musicVolumeSliderText.color = new Color(1.0f, 1.0f, 1.0f); // Set this to a random color for now

        sfxVolumeSliderText.text = Mathf.RoundToInt(sfxVolumeSlider.value).ToString() + "%";
        sfxVolumeSliderText.fontSize = 15;
        sfxVolumeSliderText.alignment = TextAnchor.MiddleLeft;
        sfxVolumeSliderText.color = new Color(1.0f, 1.0f, 1.0f); // Set this to a random color for now
    }

    public void SaveMusicVolumeSlider()
    {
        // As soon as the music volume slider is changed, save the music volume slider value
        PlayerPrefs.SetFloat("MusicSliderValue", musicVolumeSlider.value);
    }

    public void SaveSFXVolumeSlider()
    {
        // As soon as the sfx volume slider is changed, save the sfx volume slider value
        PlayerPrefs.SetFloat("SFXSliderValue", sfxVolumeSlider.value);
    }

    public void PressBackButton()
    {
        // If the player presses the back button, take them back to the main menu
        SceneManager.LoadScene("MainMenu");
    }
}
