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
        //pauseMenuTitle = GameObject.Find("Pause Menu Title Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0.0f;
    }

    public void PressResumeButton()
    {
        gameObject.SetActive(false);

        PlayerStatus.buttonPressSound.Play();
    }

    public void PressQuitButton()
    {   
        PlayerStatus.buttonPressSound.Play();
        SceneManager.LoadScene("MainMenu");   
    }
}
