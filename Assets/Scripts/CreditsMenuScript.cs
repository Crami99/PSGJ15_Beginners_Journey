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

    private float redColorTimer;
    private float greenColorTimer;

    // Start is called before the first frame update
    void Start()
    {
        creditsText = GameObject.Find("CreditsText").GetComponent<Text>();
        backText = GameObject.Find("BackText").GetComponent<Text>();

        programmersText = GameObject.Find("Programmers Text").GetComponent<Text>();
        programmerNamesText = GameObject.Find("Programmer Names Text").GetComponent<Text>();

        artDesignersText = GameObject.Find("Art Designers Text").GetComponent<Text>();
        artDesignerNamesText = GameObject.Find("Art Designer Names Text").GetComponent<Text>();

        soundComposerText = GameObject.Find("Sound Composer Text").GetComponent<Text>();
        soundComposerNameText = GameObject.Find("Sound Composer Name Text").GetComponent<Text>();

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

        creditsText.text = "Credits";
        creditsText.fontSize = 20;
        creditsText.alignment = TextAnchor.MiddleCenter;
        creditsText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        backText.text = "Back";
        backText.fontSize = 15;
        backText.alignment = TextAnchor.MiddleCenter;
        backText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        programmersText.text = "Programmers";
        programmersText.fontSize = 15;
        programmersText.alignment = TextAnchor.MiddleRight;
        programmersText.color = new Color(0.0f, greenColorTimer, 0.0f); // Set this to a random color for now

        programmerNamesText.text = "Osama Hussein\nCrami";
        programmerNamesText.fontSize = 15;
        programmerNamesText.alignment = TextAnchor.MiddleLeft;
        programmerNamesText.color = new Color(0.0f, greenColorTimer, 0.0f); // Set this to a random color for now

        artDesignersText.text = "Art designers";
        artDesignersText.fontSize = 15;
        artDesignersText.alignment = TextAnchor.MiddleRight;
        artDesignersText.color = new Color(redColorTimer, 0.0f, 0.0f); // Set this to a random color for now

        artDesignerNamesText.text = "Cryptic.\nYadiau";
        artDesignerNamesText.fontSize = 15;
        artDesignerNamesText.alignment = TextAnchor.MiddleLeft;
        artDesignerNamesText.color = new Color(redColorTimer, 0.0f, 0.0f); // Set this to a random color for now

        soundComposerText.text = "Sound composer";
        soundComposerText.fontSize = 15;
        soundComposerText.alignment = TextAnchor.MiddleRight;
        soundComposerText.color = new Color(redColorTimer, greenColorTimer, 0.0f); // Set this to a random color for now

        soundComposerNameText.text = "Darkstrikex";
        soundComposerNameText.fontSize = 15;
        soundComposerNameText.alignment = TextAnchor.MiddleLeft;
        soundComposerNameText.color = new Color(redColorTimer, greenColorTimer, 0.0f); // Set this to a random color for now
    }

    public void PressBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
