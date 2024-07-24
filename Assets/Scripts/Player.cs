using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float playerSpeed;

    private float playerHealth;
    private float playerShield;

    private float lightDamage;

    private Scene currentScene;
    private Vector2 moveInput;


    public RaycastHit2D[] results = new RaycastHit2D[10];



    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 200.0f;
        currentScene = SceneManager.GetActiveScene();

        playerShield = 100;
        playerHealth = 100;

        lightDamage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0){
            MainMenuScript.completedLevel2 = false;
            SceneManager.LoadScene("GameOverLevel2");
        }

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        
        moveInput.Normalize();



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

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Lightsource" || other.gameObject.tag == "Enemy"){
            
            Vector2 dir = transform.position - other.gameObject.transform.position;

            RaycastHit2D[] results = new RaycastHit2D[10];

            //saves result to results
            int hit = other.Raycast(dir, results, dir.magnitude);

            bool directLight = true;

            //check if Obstacle between light and player
            for(int i = 0; i < hit; i++){
                if(results[i].collider.gameObject.tag == "Obstacle"){
                    directLight = false;
                }
            }

            if(directLight){
                if(playerShield > 0){
                    playerShield = playerShield - lightDamage * Time.deltaTime;
                }else{
                    playerHealth = playerHealth - lightDamage * Time.deltaTime;
                }
            }
            Debug.Log(playerShield);
            Debug.Log(playerHealth);
        }
    }
}
