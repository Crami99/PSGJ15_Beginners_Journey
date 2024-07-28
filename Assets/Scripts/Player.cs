using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    PlayerStatus status;

    private float playerSpeed;
    private float playerHealth;
    private float playerShield;

    public bool directLight;
    private float lightDamage;

    private Vector2 moveInput;

    private Slider healthBar;
    private Slider shieldBar;

    public List<GameObject> playerInventory;

    public static GameObject inventoryHUD;
    public static GameObject pauseMenu;

    // This will be for the sword
    public static GameObject swordItem;

    // This will be for the serf
    public static GameObject serfItem;

    public static bool sword1PickedUp;
    public static bool sword2PickedUp;

    public static bool serf1PickedUp;
    public static bool serf2PickedUp;

    public RaycastHit2D[] results = new RaycastHit2D[10];

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();

        playerSpeed = 200.0f;

        playerShield = status.playerShield;
        playerHealth = status.playerHealth;
        
        playerInventory = new List<GameObject>(9);

        lightDamage = 1;
        directLight = false;

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

        //if the player presses the I key open the Inventory
        if(Input.GetKeyDown(KeyCode.I)){
            inventoryHUD.SetActive(true);
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
                
                status.playerHealth = playerHealth;
                status.playerShield = playerShield;

                //if there are rooms left, go to random room
                int roomIndex = Random.Range(0, roomList.Count);
                string nextRoom = roomList[roomIndex];
                roomList.RemoveAt(roomIndex);
                SceneManager.LoadScene(nextRoom);
            }else{
                SceneManager.LoadScene("GameWon");
            }
        }

        if (other.gameObject.tag == "Sword" && !sword1PickedUp ||
            other.gameObject.tag == "Sword" && !serf1PickedUp)
        {
            sword1PickedUp = true;

            swordItem.transform.SetParent(transform);
        }

        if (other.gameObject.tag == "Sword" && serf1PickedUp && !sword2PickedUp)
        {
            sword1PickedUp = false;
            sword2PickedUp = true;

            serfItem.SetActive(false);
            swordItem.transform.SetParent(transform);
        }

        if (other.gameObject.tag == "Serf" && !serf1PickedUp ||
            other.gameObject.tag == "Serf" && !sword1PickedUp)
        {
            serf1PickedUp = true;

            serfItem.transform.SetParent(transform);
        }

        if (other.gameObject.tag == "Serf" && sword1PickedUp && !serf2PickedUp)
        {
            serf1PickedUp = false;
            serf2PickedUp = true;

            swordItem.SetActive(false);
            serfItem.transform.SetParent(transform);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Lightsource" || other.gameObject.tag == "Enemy"){

            Vector2 dir = transform.position - other.gameObject.transform.position;

            RaycastHit2D[] results = new RaycastHit2D[10];

            //saves result to results
            int hit = other.Raycast(dir, results, dir.magnitude);

            directLight = true;

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
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Lightsource" || other.gameObject.tag == "Enemy"){
            directLight = false;
        }
    }
}
