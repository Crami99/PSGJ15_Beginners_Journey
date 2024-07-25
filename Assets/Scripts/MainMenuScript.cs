using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MainMenuScript : MonoBehaviour
{
    private Text mainMenuText;
    private Text playText;
    private Text howToPlayText;
    private Text levelSelectorText;
    private Text optionsText;
    private Text creditsText;
    public List<string> roomList = new List<string>();

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainMenu");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        mainMenuText = GameObject.Find("MainMenuText").GetComponent<Text>();
        playText = GameObject.Find("PlayText").GetComponent<Text>();
        howToPlayText = GameObject.Find("HowToPlayText").GetComponent<Text>();
        optionsText = GameObject.Find("OptionsText").GetComponent<Text>();
        creditsText = GameObject.Find("CreditsText").GetComponent<Text>();

        createRoomList();
    }

    private void Update()
    {
        mainMenuText.text = "Main Menu";
        mainMenuText.fontSize = 20;
        mainMenuText.alignment = TextAnchor.MiddleCenter;
        mainMenuText.color = new Color(0.5f, 0.8f, 0.0f); // Set this to a random color for now

        playText.text = "Play";
        playText.fontSize = 15;
        playText.alignment = TextAnchor.MiddleCenter;
        playText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        howToPlayText.text = "How to Play";
        howToPlayText.fontSize = 15;
        howToPlayText.alignment = TextAnchor.MiddleCenter;
        howToPlayText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        optionsText.text = "Options";
        optionsText.fontSize = 15;
        optionsText.alignment = TextAnchor.MiddleCenter;
        optionsText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        creditsText.text = "Credits";
        creditsText.fontSize = 15;
        creditsText.alignment = TextAnchor.MiddleCenter;
        creditsText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now
    }

    public void createRoomList()
    {
        //add all rooms to room list
        roomList.Add("Room 1");
        roomList.Add("Room 1");
        roomList.Add("Room 2");
    }

    public void PressPlayButton()
    {
        if(roomList.Count > 0){
            //if there are rooms, go to rendom romm
            int roomIndex = Random.Range(0, roomList.Count);
            string nextRoom = roomList[roomIndex];
            roomList.RemoveAt(roomIndex);
            SceneManager.LoadScene(nextRoom);
        }else{
            Debug.Log("Error: no Rooms in List");
        }
    }

    public void PressHowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void PressOptionsButton()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void PressCreditsButton()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
}
