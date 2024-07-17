using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float playerSpeed;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 5.0f;

        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movePlayer = new Vector3(horizontalInput, 0, verticalInput);

        // Move the player by keyboard arrows
        transform.Translate(movePlayer * playerSpeed * Time.deltaTime);

        // If the player moves to the right of the screen and is inside of the Level 1 scene
        if(transform.position.x >= 5.0f && currentScene.name == "Level1")
        {
            MainMenuScript.completedLevel1 = true;

            SceneManager.LoadScene("CompletedLevel1");
        }

        // Else if the player moves to the left of the screen and is inside of the Level 1 scene
        else if (transform.position.x <= -5.0f && currentScene.name == "Level1")
        {
            MainMenuScript.completedLevel1 = false;

            SceneManager.LoadScene("GameOverLevel1");
        }

        // If the player moves to the right of the screen and is inside of the Level 2 scene
        if (transform.position.x >= 5.0f && currentScene.name == "Level2")
        {
            MainMenuScript.completedLevel2 = true;

            SceneManager.LoadScene("CompletedLevel2");
        }

        // Else if the player moves to the left of the screen and is inside of the Level 2 scene
        else if (transform.position.x <= -5.0f && currentScene.name == "Level2")
        {
            MainMenuScript.completedLevel2 = false;

            SceneManager.LoadScene("GameOverLevel2");
        }

        // If the player moves to the right of the screen and is inside of the Level 3 scene
        if (transform.position.x >= 5.0f && currentScene.name == "Level3")
        {
            SceneManager.LoadScene("CompletedLevel3");
        }

        // Else if the player moves to the left of the screen and is inside of the Level 3 scene
        else if (transform.position.x <= -5.0f && currentScene.name == "Level3")
        {
            SceneManager.LoadScene("GameOverLevel3");
        }
    }
}
