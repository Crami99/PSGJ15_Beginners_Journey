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

    private int enemyLineIndex;

    public RaycastHit2D[] results = new RaycastHit2D[10];

    private AudioSource enemySawPlayerLine1, enemySawPlayerLine2, enemySawPlayerLine3, enemySawPlayerLine4,
        enemySawPlayerLine5, enemySawPlayerLine6, enemySawPlayerLine7, enemySawPlayerLine8, enemySawPlayerLine9;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 200.0f;
        currentScene = SceneManager.GetActiveScene();

        playerShield = 100;
        playerHealth = 100;

        lightDamage = 1;

        enemySawPlayerLine1 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine1").GetComponent<AudioSource>();
        enemySawPlayerLine2 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine2").GetComponent<AudioSource>();
        enemySawPlayerLine3 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine3").GetComponent<AudioSource>();
        enemySawPlayerLine4 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine4").GetComponent<AudioSource>();
        enemySawPlayerLine5 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine5").GetComponent<AudioSource>();
        enemySawPlayerLine6 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine6").GetComponent<AudioSource>();
        enemySawPlayerLine7 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine7").GetComponent<AudioSource>();
        enemySawPlayerLine8 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine8").GetComponent<AudioSource>();
        enemySawPlayerLine9 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine9").GetComponent<AudioSource>();

        enemySawPlayerLine1.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine2.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine3.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine4.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine5.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine6.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine7.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine8.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine9.volume = OptionsMenuScript.sfxVolumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        enemyLineIndex = Random.Range(0, 9);

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        
        moveInput.Normalize();

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

    private void PlayEnemyCaughtPlayerLines()
    {
        if (enemyLineIndex == 0)
        {
            enemySawPlayerLine1.Play();
            enemySawPlayerLine2.Stop();
            enemySawPlayerLine3.Stop();
            enemySawPlayerLine4.Stop();
            enemySawPlayerLine5.Stop();
            enemySawPlayerLine6.Stop();
            enemySawPlayerLine7.Stop();
            enemySawPlayerLine8.Stop();
            enemySawPlayerLine9.Stop();

            enemySawPlayerLine1.transform.position = transform.position;
        }

        if (enemyLineIndex == 1)
        {
            enemySawPlayerLine1.Stop();
            enemySawPlayerLine2.Play();
            enemySawPlayerLine3.Stop();
            enemySawPlayerLine4.Stop();
            enemySawPlayerLine5.Stop();
            enemySawPlayerLine6.Stop();
            enemySawPlayerLine7.Stop();
            enemySawPlayerLine8.Stop();
            enemySawPlayerLine9.Stop();

            enemySawPlayerLine2.transform.position = transform.position;
        }

        if (enemyLineIndex == 2)
        {
            enemySawPlayerLine1.Stop();
            enemySawPlayerLine2.Stop();
            enemySawPlayerLine3.Play();
            enemySawPlayerLine4.Stop();
            enemySawPlayerLine5.Stop();
            enemySawPlayerLine6.Stop();
            enemySawPlayerLine7.Stop();
            enemySawPlayerLine8.Stop();
            enemySawPlayerLine9.Stop();

            enemySawPlayerLine3.transform.position = transform.position;
        }

        if (enemyLineIndex == 3)
        {
            enemySawPlayerLine1.Stop();
            enemySawPlayerLine2.Stop();
            enemySawPlayerLine3.Stop();
            enemySawPlayerLine4.Play();
            enemySawPlayerLine5.Stop();
            enemySawPlayerLine6.Stop();
            enemySawPlayerLine7.Stop();
            enemySawPlayerLine8.Stop();
            enemySawPlayerLine9.Stop();

            enemySawPlayerLine4.transform.position = transform.position;
        }

        if (enemyLineIndex == 4)
        {
            enemySawPlayerLine1.Stop();
            enemySawPlayerLine2.Stop();
            enemySawPlayerLine3.Stop();
            enemySawPlayerLine4.Stop();
            enemySawPlayerLine5.Play();
            enemySawPlayerLine6.Stop();
            enemySawPlayerLine7.Stop();
            enemySawPlayerLine8.Stop();
            enemySawPlayerLine9.Stop();

            enemySawPlayerLine5.transform.position = transform.position;
        }

        if (enemyLineIndex == 5)
        {
            enemySawPlayerLine1.Stop();
            enemySawPlayerLine2.Stop();
            enemySawPlayerLine3.Stop();
            enemySawPlayerLine4.Stop();
            enemySawPlayerLine5.Stop();
            enemySawPlayerLine6.Play();
            enemySawPlayerLine7.Stop();
            enemySawPlayerLine8.Stop();
            enemySawPlayerLine9.Stop();

            enemySawPlayerLine6.transform.position = transform.position;
        }

        if (enemyLineIndex == 6)
        {
            enemySawPlayerLine1.Stop();
            enemySawPlayerLine2.Stop();
            enemySawPlayerLine3.Stop();
            enemySawPlayerLine4.Stop();
            enemySawPlayerLine5.Stop();
            enemySawPlayerLine6.Stop();
            enemySawPlayerLine7.Play();
            enemySawPlayerLine8.Stop();
            enemySawPlayerLine9.Stop();

            enemySawPlayerLine7.transform.position = transform.position;
        }

        if (enemyLineIndex == 7)
        {
            enemySawPlayerLine1.Stop();
            enemySawPlayerLine2.Stop();
            enemySawPlayerLine3.Stop();
            enemySawPlayerLine4.Stop();
            enemySawPlayerLine5.Stop();
            enemySawPlayerLine6.Stop();
            enemySawPlayerLine7.Stop();
            enemySawPlayerLine8.Play();
            enemySawPlayerLine9.Stop();

            enemySawPlayerLine8.transform.position = transform.position;
        }

        if (enemyLineIndex == 8)
        {
            enemySawPlayerLine1.Stop();
            enemySawPlayerLine2.Stop();
            enemySawPlayerLine3.Stop();
            enemySawPlayerLine4.Stop();
            enemySawPlayerLine5.Stop();
            enemySawPlayerLine6.Stop();
            enemySawPlayerLine7.Stop();
            enemySawPlayerLine8.Stop();
            enemySawPlayerLine9.Play();

            enemySawPlayerLine9.transform.position = transform.position;
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput.x * playerSpeed * Time.deltaTime, moveInput.y * playerSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lightsource" || collision.gameObject.tag == "Enemy")
        {
            PlayEnemyCaughtPlayerLines();
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
            Debug.Log(playerShield);
            Debug.Log(playerHealth);
        }
    }
}
