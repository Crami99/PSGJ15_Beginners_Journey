using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Player : MonoBehaviour
{
    PlayerStatus status;

    private float lightDamage;
    public bool directLight;

    private Slider healthBar;
    private Slider shieldBar;

    public static GameObject inventoryHUD;
    public static GameObject pauseMenu;

    public RaycastHit2D[] results = new RaycastHit2D[10];

    private Vector2 moveInput;

    private AudioSource noCombatMusic;
    private AudioSource combatMusic;

    AudioSource playerHitLightSound;
    List<string> playerHitLightClips;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();

        lightDamage = 50;
        directLight = false;

        healthBar = GameObject.Find("Health Bar Slider").GetComponent<Slider>();
        shieldBar = GameObject.Find("Shield Bar Slider").GetComponent<Slider>();

        inventoryHUD = GameObject.Find("Inventory UI");
        inventoryHUD.SetActive(false);

        pauseMenu = GameObject.Find("Pause Menu UI");
        pauseMenu.SetActive(false);

        noCombatMusic = GameObject.Find("NoCombatMusic").GetComponent<AudioSource>();
        combatMusic = GameObject.Find("CombatMusic").GetComponent<AudioSource>();

        noCombatMusic.volume = PlayerPrefs.GetFloat("MusicSliderValue", 100f);
        combatMusic.volume = 0;

        noCombatMusic.loop = true;
        combatMusic.loop = true;

        noCombatMusic.clip = Resources.Load<AudioClip>("Music/ShadowGameNoCombat");
        combatMusic.clip = Resources.Load<AudioClip>("Music/ShadowGameCombat");

        combatMusic.Play();
        noCombatMusic.Play();

        playerHitLightSound = GameObject.Find("PlayerCollidedWithLight").GetComponent<AudioSource>();
        playerHitLightSound.volume = PlayerPrefs.GetFloat("SFXSliderValue", 100f);

        playerHitLightClips = new List<string> { "player touching light", "player burning from light" };
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStatus.menuMusic.isPlaying)
        {
            PlayerStatus.menuMusic.Stop();
            PlayerStatus.menuMusic.volume = 0;
        }

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        
        moveInput.Normalize();

        healthBar.value = status.health + status.healthMod;
        shieldBar.value = status.shield + status.shieldMod;

        //regen shield
        if(!directLight && status.shield < status.shieldBase){
            status.shield += 5 * Time.deltaTime;
        }

        // Show the game over screen when the player's health is lower than healthMod
        if(status.health + status.healthMod <= 0){
            SceneManager.LoadScene("GameOver");
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseMenu.SetActive(true);
        }

        //if the player presses the I key open the Inventory
        if(Input.GetKeyDown(KeyCode.I)){
            inventoryHUD.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        //rigid bodies should be moved in FixedUpdate()
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput.x * status.speed * status.speedMod * Time.deltaTime,
                                                           moveInput.y * status.speed * status.speedMod * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the target is reached go to next level or GameWon if no next level exists
        if(other.gameObject.tag == "Target"){ 
            status.NextRoom();
        }

        if (other.gameObject.name == "Torch" && combatMusic.isPlaying ||
            other.gameObject.tag == "Enemy" && combatMusic.isPlaying ||
            other.gameObject.name == "Torch" && noCombatMusic.isPlaying ||
            other.gameObject.tag == "Enemy" && noCombatMusic.isPlaying)
        {
            combatMusic.volume = PlayerPrefs.GetFloat("MusicSliderValue", 100f);
            noCombatMusic.volume = 0;
        }

        if (other.gameObject.tag == "Lightsource" && !playerHitLightSound.isPlaying)
        {
            playerHitLightSound.clip = Resources.Load<AudioClip>("SoundEffects/Player/" + playerHitLightClips[0]);
            playerHitLightSound.Play();
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

            if (!playerHitLightSound.isPlaying)
            {
                playerHitLightSound.clip = Resources.Load<AudioClip>("SoundEffects/Player/" + playerHitLightClips[1]);
                playerHitLightSound.Play();
            }

            if (directLight){
                if(status.shield +status.shieldMod > 0){
                    //status.shield = status.shield - lightDamage * Time.deltaTime;
                }else{
                    status.health = status.health - lightDamage * Time.deltaTime;
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Lightsource" || other.gameObject.tag == "Enemy"){
            directLight = false;

            combatMusic.volume = 0;
            noCombatMusic.volume = PlayerPrefs.GetFloat("MusicSliderValue", 100f);
        }
    }
}
