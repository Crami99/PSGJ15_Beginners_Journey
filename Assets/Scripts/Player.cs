using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float playerSpeed;
    public static Scene currentScene;

    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 200.0f;
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        
        moveInput.Normalize();

        //GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput.x * playerSpeed * Time.deltaTime, moveInput.y * playerSpeed * Time.deltaTime);
    
        // Move the player by keyboard arrows
        //transform.Translate(movePlayer * playerSpeed * Time.deltaTime);

        /*
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
        */
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput.x * playerSpeed * Time.deltaTime, moveInput.y * playerSpeed * Time.deltaTime);
    }
}
