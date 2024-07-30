using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsMenuScript : MonoBehaviour
{
    private Text creditsText;
    private Text backText;

    private Text programmersText;
    private Text programmerNamesText;

    private Text artDesignersText;
    private Text artDesignerNamesText;

    private Text soundComposerText;
    private Text soundComposerNameText;

    private Text introVideoText;
    private Text introVideoNameText;

    private Text enemyLinesText;
    private Text enemyLinesNameText;

    private float redColorTimer;
    private float greenColorTimer;

    // Start is called before the first frame update
    void Start()
    {
        creditsText = GameObject.Find("CreditsText").GetComponent<Text>();

        programmersText = GameObject.Find("Programmers Text").GetComponent<Text>();
        programmerNamesText = GameObject.Find("Programmer Names Text").GetComponent<Text>();

        artDesignersText = GameObject.Find("Art Designers Text").GetComponent<Text>();
        artDesignerNamesText = GameObject.Find("Art Designer Names Text").GetComponent<Text>();

        soundComposerText = GameObject.Find("Sound Composer Text").GetComponent<Text>();
        soundComposerNameText = GameObject.Find("Sound Composer Name Text").GetComponent<Text>();

        introVideoText = GameObject.Find("Intro Video Text").GetComponent<Text>();
        introVideoNameText = GameObject.Find("Intro Video Name Text").GetComponent<Text>();

        enemyLinesText = GameObject.Find("Enemy Lines Text").GetComponent<Text>();
        enemyLinesNameText = GameObject.Find("Enemy Lines Name Text").GetComponent<Text>();

        redColorTimer = 0.0f;
        greenColorTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        redColorTimer += Time.deltaTime;

        if (redColorTimer >= 2.0f)
        {
            redColorTimer = 2.0f;
        }

        greenColorTimer += Time.deltaTime;

        if (greenColorTimer >= 2.0f)
        {
            greenColorTimer = 2.0f;
        }

        programmersText.text = "Programming";
        programmersText.fontSize = 20;
        programmersText.alignment = TextAnchor.MiddleRight;
        programmersText.color = new Color(0.0f, greenColorTimer, 0.0f); // Set this to a random color for now

        programmerNamesText.text = "Osama Hussein\nCrami";
        programmerNamesText.fontSize = 20;
        programmerNamesText.alignment = TextAnchor.MiddleLeft;
        programmerNamesText.color = new Color(0.0f, greenColorTimer, 0.0f); // Set this to a random color for now

        artDesignersText.text = "Art";
        artDesignersText.fontSize = 20;
        artDesignersText.alignment = TextAnchor.MiddleRight;
        artDesignersText.color = new Color(redColorTimer, 0.0f, 0.0f); // Set this to a random color for now

        artDesignerNamesText.text = "Cryptic.\nYadiau";
        artDesignerNamesText.fontSize = 20;
        artDesignerNamesText.alignment = TextAnchor.MiddleLeft;
        artDesignerNamesText.color = new Color(redColorTimer, 0.0f, 0.0f); // Set this to a random color for now

        soundComposerText.text = "Sound composer";
        soundComposerText.fontSize = 20;
        soundComposerText.alignment = TextAnchor.MiddleRight;
        soundComposerText.color = new Color(redColorTimer, greenColorTimer, 0.0f); // Set this to a random color for now

        soundComposerNameText.text = "Darkstrikex";
        soundComposerNameText.fontSize = 20;
        soundComposerNameText.alignment = TextAnchor.MiddleLeft;
        soundComposerNameText.color = new Color(redColorTimer, greenColorTimer, 0.0f); // Set this to a random color for now

        introVideoText.text = "Intro Video";
        introVideoText.fontSize = 20;
        introVideoText.alignment = TextAnchor.MiddleRight;
        introVideoText.color = new Color(0.0f, greenColorTimer, 0.5f); // Set this to a random color for now

        introVideoNameText.text = "Yadiau";
        introVideoNameText.fontSize = 20;
        introVideoNameText.alignment = TextAnchor.MiddleLeft;
        introVideoNameText.color = new Color(0.0f, greenColorTimer, 0.5f); // Set this to a random color for now

        enemyLinesText.text = "Voice Acting";
        enemyLinesText.fontSize = 20;
        enemyLinesText.alignment = TextAnchor.MiddleRight;
        enemyLinesText.color = new Color(redColorTimer, 0.0f, 0.5f); // Set this to a random color for now

        enemyLinesNameText.text = "Osama Hussein";
        enemyLinesNameText.fontSize = 20;
        enemyLinesNameText.alignment = TextAnchor.MiddleLeft;
        enemyLinesNameText.color = new Color(redColorTimer, 0.0f, 0.5f); // Set this to a random color for now
    }

    public void PressBackButton()
    {   
        PlayerStatus.buttonPressSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
