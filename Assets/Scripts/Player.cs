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
    public static GameObject pauseMenu;

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

        pauseMenu = GameObject.Find("Pause Menu UI");
        pauseMenu.SetActive(false);

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
        if(playerHealth <= 0.0f){
            SceneManager.LoadScene("GameOver");
        }
    }
    void FixedUpdate()
    {
        //rigid bodies should be moved in FixedUpdate()
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput.x * playerSpeed * Time.deltaTime, moveInput.y * playerSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the target is reached go to next level or main menu if no next level exists
        if(other.gameObject.tag == "Target"){

            List<string> roomList = GameObject.Find("MainMenuScript").GetComponent<MainMenuScript>().roomList;
            
            if(roomList.Count > 0){
                string nextRoom = roomList[0];
                roomList.RemoveAt(0);
                SceneManager.LoadScene(nextRoom);
            }else{
                SceneManager.LoadScene("GameWon");
            }
        }
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
        }
    }
}
