using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour
{
    private Text levelSelectorText;
    private Text backText;
    private Text level1TextUnlocked;
    private Text level2TextUnlocked;
    private Text level3TextUnlocked;
    private Text level2TextLocked;
    private Text level3TextLocked;

    private GameObject level2UnlockedButton;
    private GameObject level2LockedButton;
    private GameObject level3UnlockedButton;
    private GameObject level3LockedButton;

    private int levelSelectorButtonLockedLineIndex;

    private AudioSource levelSelectorButtonLockedLine1, levelSelectorButtonLockedLine2, levelSelectorButtonLockedLine3,
        levelSelectorButtonLockedLine4, levelSelectorButtonLockedLine5, levelSelectorButtonLockedLine6,
        levelSelectorButtonLockedLine7, levelSelectorButtonLockedLine8, levelSelectorButtonLockedLine9;

    // Start is called before the first frame update
    void Start()
    {
        levelSelectorText = GameObject.Find("LevelSelectorText").GetComponent<Text>();
        backText = GameObject.Find("BackText").GetComponent<Text>();

        level1TextUnlocked = GameObject.Find("Level1Text").GetComponent<Text>();
        level2TextUnlocked = GameObject.Find("Level2Text").GetComponent<Text>();
        level3TextUnlocked = GameObject.Find("Level3Text").GetComponent<Text>();

        level2TextLocked = GameObject.Find("Level2TextLocked").GetComponent<Text>();
        level3TextLocked = GameObject.Find("Level3TextLocked").GetComponent<Text>();

        level2UnlockedButton = GameObject.Find("Level2Button");
        level2LockedButton = GameObject.Find("Level2ButtonLocked");

        level3UnlockedButton = GameObject.Find("Level3Button");
        level3LockedButton = GameObject.Find("Level3ButtonLocked");

        levelSelectorButtonLockedLine1 = GameObject.Find("ButtonLockedSounds/ButtonLockedLine1").GetComponent<AudioSource>();
        levelSelectorButtonLockedLine2 = GameObject.Find("ButtonLockedSounds/ButtonLockedLine2").GetComponent<AudioSource>();
        levelSelectorButtonLockedLine3 = GameObject.Find("ButtonLockedSounds/ButtonLockedLine3").GetComponent<AudioSource>();
        levelSelectorButtonLockedLine4 = GameObject.Find("ButtonLockedSounds/ButtonLockedLine4").GetComponent<AudioSource>();
        levelSelectorButtonLockedLine5 = GameObject.Find("ButtonLockedSounds/ButtonLockedLine5").GetComponent<AudioSource>();
        levelSelectorButtonLockedLine6 = GameObject.Find("ButtonLockedSounds/ButtonLockedLine6").GetComponent<AudioSource>();
        levelSelectorButtonLockedLine7 = GameObject.Find("ButtonLockedSounds/ButtonLockedLine7").GetComponent<AudioSource>();
        levelSelectorButtonLockedLine8 = GameObject.Find("ButtonLockedSounds/ButtonLockedLine8").GetComponent<AudioSource>();
        levelSelectorButtonLockedLine9 = GameObject.Find("ButtonLockedSounds/ButtonLockedLine9").GetComponent<AudioSource>();

        levelSelectorButtonLockedLine1.volume = OptionsMenuScript.sfxVolumeSlider.value;
        levelSelectorButtonLockedLine2.volume = OptionsMenuScript.sfxVolumeSlider.value;
        levelSelectorButtonLockedLine3.volume = OptionsMenuScript.sfxVolumeSlider.value;
        levelSelectorButtonLockedLine4.volume = OptionsMenuScript.sfxVolumeSlider.value;
        levelSelectorButtonLockedLine5.volume = OptionsMenuScript.sfxVolumeSlider.value;
        levelSelectorButtonLockedLine6.volume = OptionsMenuScript.sfxVolumeSlider.value;
        levelSelectorButtonLockedLine7.volume = OptionsMenuScript.sfxVolumeSlider.value;
        levelSelectorButtonLockedLine8.volume = OptionsMenuScript.sfxVolumeSlider.value;
        levelSelectorButtonLockedLine9.volume = OptionsMenuScript.sfxVolumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        levelSelectorButtonLockedLineIndex = Random.Range(0, 9);

        levelSelectorText.text = "Level Selector";
        levelSelectorText.fontSize = 20;
        levelSelectorText.alignment = TextAnchor.MiddleCenter;
        levelSelectorText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        backText.text = "Back";
        backText.fontSize = 15;
        backText.alignment = TextAnchor.MiddleCenter;
        backText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        level1TextUnlocked.text = "Level 1";
        level1TextUnlocked.fontSize = 15;
        level1TextUnlocked.alignment = TextAnchor.MiddleCenter;
        level1TextUnlocked.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        level2TextUnlocked.text = "Level 2";
        level2TextUnlocked.fontSize = 15;
        level2TextUnlocked.alignment = TextAnchor.MiddleCenter;
        level2TextUnlocked.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        level3TextUnlocked.text = "Level 3";
        level3TextUnlocked.fontSize = 15;
        level3TextUnlocked.alignment = TextAnchor.MiddleCenter;
        level3TextUnlocked.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        // If Level 2 is locked
        level2TextLocked.text = "Level 2";
        level2TextLocked.fontSize = 15;
        level2TextLocked.alignment = TextAnchor.MiddleCenter;
        level2TextLocked.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        // If Level 3 is locked
        level3TextLocked.text = "Level 3";
        level3TextLocked.fontSize = 15;
        level3TextLocked.alignment = TextAnchor.MiddleCenter;
        level3TextLocked.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        if (MainMenuScript.completedLevel1 == true)
        {
            level2LockedButton.SetActive(false);
            level2UnlockedButton.SetActive(true);
        }

        else if (MainMenuScript.completedLevel1 == false)
        {
            level2LockedButton.SetActive(true);
            level2UnlockedButton.SetActive(false);
        }

        if (MainMenuScript.completedLevel2 == true)
        {
            level3LockedButton.SetActive(false);
            level3UnlockedButton.SetActive(true);
        }

        else if (MainMenuScript.completedLevel2 == false)
        {
            level3LockedButton.SetActive(true);
            level3UnlockedButton.SetActive(false);
        }
    }

    public void PressBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PressLevel1UnlockedButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PressLevel2UnlockedButton()
    {
        SceneManager.LoadScene("Level2");
    }

    public void PressLevel3UnlockedButton()
    {
        SceneManager.LoadScene("Level3");
    }

    public void PressLevel2LockedButton()
    {
        switch (levelSelectorButtonLockedLineIndex)
        {
            case 0:
                levelSelectorButtonLockedLine1.Play();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 1:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Play();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 2:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Play();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 3:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Play();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 4:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Play();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 5:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Play();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 6:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Play();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 7:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Play();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 8:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Play();

                break;

            default:
                break;
        }
    }

    public void PressLevel3LockedButton()
    {
        switch (levelSelectorButtonLockedLineIndex)
        {
            case 0:
                levelSelectorButtonLockedLine1.Play();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 1:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Play();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 2:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Play();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 3:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Play();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 4:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Play();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 5:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Play();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 6:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Play();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 7:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Play();
                levelSelectorButtonLockedLine9.Stop();

                break;

            case 8:
                levelSelectorButtonLockedLine1.Stop();
                levelSelectorButtonLockedLine2.Stop();
                levelSelectorButtonLockedLine3.Stop();
                levelSelectorButtonLockedLine4.Stop();
                levelSelectorButtonLockedLine5.Stop();
                levelSelectorButtonLockedLine6.Stop();
                levelSelectorButtonLockedLine7.Stop();
                levelSelectorButtonLockedLine8.Stop();
                levelSelectorButtonLockedLine9.Play();

                break;

            default:
                break;
        }
    }
}
