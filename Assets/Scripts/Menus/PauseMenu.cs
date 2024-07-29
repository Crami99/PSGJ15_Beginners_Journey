using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private Text pauseMenuTitle;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuTitle = GameObject.Find("Pause Menu Title Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pauseMenuTitle.text = "Game Paused!";
        pauseMenuTitle.fontSize = 25;
        pauseMenuTitle.alignment = TextAnchor.MiddleCenter;
        pauseMenuTitle.color = new Color(0.7f, 0.4f, 0.0f);

        Time.timeScale = 0.0f;
    }

    public void PressResumeButton()
    {
        gameObject.SetActive(false);
    }

    public void PressQuitButton()
    {
        Destroy(GameObject.Find("MainMenuScript"));
        Destroy(GameObject.Find("PlayerStatusScript"));
        SceneManager.LoadScene("MainMenu");
    }

}
