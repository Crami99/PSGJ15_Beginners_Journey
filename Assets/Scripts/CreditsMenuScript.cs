using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsMenuScript : MonoBehaviour
{
    private Text creditsText;
    private Text backText;

    // Start is called before the first frame update
    void Start()
    {
        creditsText = GameObject.Find("CreditsText").GetComponent<Text>();
        backText = GameObject.Find("BackText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        creditsText.text = "Credits";
        creditsText.fontSize = 20;
        creditsText.alignment = TextAnchor.MiddleCenter;
        creditsText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        backText.text = "Back";
        backText.fontSize = 15;
        backText.alignment = TextAnchor.MiddleCenter;
        backText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now
    }

    public void PressBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
