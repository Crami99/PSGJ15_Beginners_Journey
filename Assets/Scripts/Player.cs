using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float playerSpeed;

    private float playerHealth;
    private float playerShield;

    private float lightDamage;

    public static Scene currentScene;
    private Vector2 moveInput;

    private Slider healthBar;
    private Slider shieldBar;

    public static GameObject inventoryHUD;

    public RaycastHit2D[] results = new RaycastHit2D[10];

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 200.0f;
        currentScene = SceneManager.GetActiveScene();

        playerShield = 100;
        playerHealth = 100;

        lightDamage = 1;

        healthBar = GameObject.Find("Health Bar Slider").GetComponent<Slider>();
        shieldBar = GameObject.Find("Shield Bar Slider").GetComponent<Slider>();

        inventoryHUD = GameObject.Find("Inventory UI");
        inventoryHUD.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        
        moveInput.Normalize();

        healthBar.value = playerHealth;
        shieldBar.value = playerShield;

        // Show the game over screen when the player's health is at 0
        ShowGameOverScreen();
    }

    void ShowGameOverScreen()
    {
        // If the player's health is at 0 and they're in Level 1, show the game over screen for Level 1
        if (playerHealth <= 0.0f && currentScene.name == "Level1")
        {
            MainMenuScript.completedLevel1 = false;

            SceneManager.LoadScene("GameOverLevel1");
        }

        // If the player's health is at 0 and they're in Level 2, show the game over screen for Level 2
        else if (playerHealth <= 0.0f && currentScene.name == "Level2")
        {
            MainMenuScript.completedLevel2 = false;

            SceneManager.LoadScene("GameOverLevel2");
        }

        // If the player's health is at 0 and they're in Level 3, show the game over screen for Level 3
        else if (playerHealth <= 0.0f && currentScene.name == "Level3")
        {
            SceneManager.LoadScene("GameOverLevel3");
        }
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
