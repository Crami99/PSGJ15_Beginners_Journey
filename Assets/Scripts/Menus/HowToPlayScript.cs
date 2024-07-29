using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlayScript : MonoBehaviour
{
    private Text howToPlayText;
    private Text backText;

    // Start is called before the first frame update
    void Start()
    {
        howToPlayText = GameObject.Find("HowToPlayText").GetComponent<Text>();
        backText = GameObject.Find("BackText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        howToPlayText.text = "How to Play";
        howToPlayText.fontSize = 20;
        howToPlayText.alignment = TextAnchor.MiddleCenter;
        howToPlayText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        backText.text = "Back";
        backText.fontSize = 15;
        backText.alignment = TextAnchor.MiddleCenter;
        backText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now
    }

    public void PressBackButton()
    {
        Debug.Log("Error: no Rooms in List");
        Destroy(GameObject.Find("MainMenuScript"));
        Destroy(GameObject.Find("PlayerStatusScript"));
        SceneManager.LoadScene("MainMenu");

        PlayerStatus.buttonPressSound.Play();
    }
}
