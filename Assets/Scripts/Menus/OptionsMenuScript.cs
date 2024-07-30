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
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicSliderValue", 100f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXSliderValue", 100f);

        musicVolumeSliderText = GameObject.Find("MusicVolumeSliderText").GetComponent<Text>();
        sfxVolumeSliderText = GameObject.Find("SFXVolumeSliderText").GetComponent<Text>();

        musicVolumeSliderText.text = Mathf.RoundToInt(musicVolumeSlider.value * 100).ToString() + "%";
        musicVolumeSliderText.fontSize = 14;
        musicVolumeSliderText.alignment = TextAnchor.MiddleLeft;
        musicVolumeSliderText.color = new Color(250.0f, 250.0f, 250.0f); // Set this to a random color for now

        sfxVolumeSliderText.text = Mathf.RoundToInt(sfxVolumeSlider.value * 100).ToString() + "%";
        sfxVolumeSliderText.fontSize = 14;
        sfxVolumeSliderText.alignment = TextAnchor.MiddleLeft;
        sfxVolumeSliderText.color = new Color(250.0f, 250.0f, 250.0f); // Set this to a random color for now
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the text as the player modifies the sliders
        musicVolumeSliderText.text = Mathf.RoundToInt(musicVolumeSlider.value * 100).ToString() + "%";

        sfxVolumeSliderText.text = Mathf.RoundToInt(sfxVolumeSlider.value * 100).ToString() + "%";

        PlayerStatus.menuMusic.volume = PlayerPrefs.GetFloat("MusicSliderValue", 100f);

        PlayerStatus.buttonPressSound.volume = PlayerPrefs.GetFloat("SFXSliderValue", 100f);
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
        Destroy(GameObject.Find("MainMenuScript"));
        Destroy(GameObject.Find("PlayerStatusScript"));
        SceneManager.LoadScene("MainMenu");

        PlayerStatus.buttonPressSound.Play();
    }
}
