using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Text gameOverText;
    private Text restartText;
    private Text quitText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        restartText = GameObject.Find("RestartText").GetComponent<Text>();
        quitText = GameObject.Find("QuitText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gameOverText.text = "You Died!";
        gameOverText.fontSize = 20;
        gameOverText.alignment = TextAnchor.MiddleCenter;
        gameOverText.color = new Color(1.0f, 0.0f, 0.0f); // Set this to a random color for now

        restartText.text = "Restart";
        restartText.fontSize = 15;
        restartText.alignment = TextAnchor.MiddleCenter;
        restartText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now

        quitText.text = "Quit";
        quitText.fontSize = 15;
        quitText.alignment = TextAnchor.MiddleCenter;
        quitText.color = new Color(0.0f, 0.0f, 1.0f); // Set this to a random color for now
    }
    
    public void PressRestartButton()
    {
        GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>().ResetStats();
        GameObject.Find("MainMenuScript").GetComponent<MainMenuScript>().createRoomList();

        List<string> roomList = GameObject.Find("MainMenuScript").GetComponent<MainMenuScript>().roomList;

        if(roomList.Count > 0){
            int roomIndex = Random.Range(0, roomList.Count);
            string nextRoom = roomList[roomIndex];
            roomList.RemoveAt(roomIndex);
            SceneManager.LoadScene(nextRoom);
        }else{
            Debug.Log("Error: no Rooms in List");
            Destroy(GameObject.Find("MainMenuScript"));
            Destroy(GameObject.Find("PlayerStatusScript"));
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void PressQuitButton()
    {
        GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>().ResetStats();
        Destroy(GameObject.Find("MainMenuScript"));
        SceneManager.LoadScene("MainMenu");
    }
}
