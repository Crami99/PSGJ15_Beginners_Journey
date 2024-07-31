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

        if(Input.GetKeyDown(KeyCode.Escape)){
            gameObject.SetActive(false);
        }
    }

    public void PressResumeButton()
    {   
        PlayerStatus.buttonPressSound.Play();
        gameObject.SetActive(false);
    }

    public void PressQuitButton()
    {   
        PlayerStatus.buttonPressSound.Play();
        SceneManager.LoadScene("MainMenu");   
    }
}
