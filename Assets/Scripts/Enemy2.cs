using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{
    private AudioSource enemyLine1, enemyLine2, enemyLine3, enemyLine4, enemyLine5,
        enemyLine6, enemyLine7, enemyLine8, enemyLine9;

    private int enemyLineIndex;

    private GameObject player;
    private GameObject lantern2;

    private float rotateSpeed = 2000.0f;

    private bool enemySawPlayer;
    private bool enemyIsPatrolling;

    private Transform aiPatrolRoute1, aiPatrolRoute2, aiPatrolRoute3;

    private float timeForAIToLookAround;

    private bool enemylooked1, enemylooked2, enemylooked3;

    // Start is called before the first frame update
    void Start()
    {
        // Set the enemy saw player to false because the enemy shouldn't see the player as soon as the level starts
        enemySawPlayer = false;

        enemyIsPatrolling = true;

        timeForAIToLookAround = 0;

        enemylooked1 = false;
        enemylooked2 = false;
        enemylooked3 = false;

        //aiPatrolRoute1 = GameObject.Find("Enemy1Paths/Enemy1PathA").GetComponent<Transform>();
        //aiPatrolRoute2 = GameObject.Find("Enemy1Paths/Enemy1PathB").GetComponent<Transform>();
        //aiPatrolRoute3 = GameObject.Find("Enemy1Paths/Enemy1PathC").GetComponent<Transform>();

        // Find the player game object
        player = GameObject.Find("Player");

        // Find the lantern game object
        lantern2 = GameObject.Find("Lantern 2");

        // Find every single enemy line in the scene
        enemyLine1 = GameObject.Find("EnemyLineSounds/EnemyLine1").GetComponent<AudioSource>();
        enemyLine2 = GameObject.Find("EnemyLineSounds/EnemyLine2").GetComponent<AudioSource>();
        enemyLine3 = GameObject.Find("EnemyLineSounds/EnemyLine3").GetComponent<AudioSource>();
        enemyLine4 = GameObject.Find("EnemyLineSounds/EnemyLine4").GetComponent<AudioSource>();
        enemyLine5 = GameObject.Find("EnemyLineSounds/EnemyLine5").GetComponent<AudioSource>();
        enemyLine6 = GameObject.Find("EnemyLineSounds/EnemyLine6").GetComponent<AudioSource>();
        enemyLine7 = GameObject.Find("EnemyLineSounds/EnemyLine7").GetComponent<AudioSource>();
        enemyLine8 = GameObject.Find("EnemyLineSounds/EnemyLine8").GetComponent<AudioSource>();
        enemyLine9 = GameObject.Find("EnemyLineSounds/EnemyLine9").GetComponent<AudioSource>();

        enemyLine1.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLine2.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLine3.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLine4.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLine5.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLine6.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLine7.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLine8.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLine9.volume = OptionsMenuScript.sfxVolumeSlider.value;

        // Randomize between enemy line indexes for different dialogue each time
        enemyLineIndex = Random.Range(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        // Randomize between enemy line indexes for different dialogue each time
        enemyLineIndex = Random.Range(0, 9);

        // If the enemy 1 sees the player, move towards the player
        if (Vector3.Distance(transform.position, player.transform.position) <= 2.5f)
        {
            Enemy1CaughtPlayer();

            lantern2.transform.rotation = Quaternion.LookRotation(lantern2.transform.forward * rotateSpeed,
                player.transform.position);

            //transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }

        // If the enemy and player distance is greater than or equal to 4.0, make the enemy saw player false
        else if (Vector3.Distance(transform.position, player.transform.position) > 2.5f)
        {
            //EnemyPatrol1();
        }

        ShowGameOverScreen();
    }

    void EnemyPatrol1()
    {
        // Stops moving towards the player
        enemySawPlayer = false;
        enemyIsPatrolling = true;

        // Basic enemy movement for patrol route 1
        if (enemylooked1 == false && enemyIsPatrolling == true && enemySawPlayer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, aiPatrolRoute1.position,
                Time.deltaTime * 3.0f);

            timeForAIToLookAround += Time.deltaTime;

            if (timeForAIToLookAround >= 2.0f)
            {
                enemylooked1 = true;

                timeForAIToLookAround = 0.0f;
            }
        }

        if (enemylooked1 == true && enemylooked2 == false && enemyIsPatrolling == true &&
            enemySawPlayer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, aiPatrolRoute2.position,
            Time.deltaTime * 3.0f);

            timeForAIToLookAround += Time.deltaTime;

            if (timeForAIToLookAround >= 2.0f)
            {
                enemylooked2 = true;

                timeForAIToLookAround = 0.0f;
            }
        }

        if (enemylooked1 == true && enemylooked2 == true && enemylooked3 == false &&
            enemyIsPatrolling == true && enemySawPlayer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, aiPatrolRoute3.position,
            Time.deltaTime * 3.0f);

            timeForAIToLookAround += Time.deltaTime;

            if (timeForAIToLookAround >= 2.0f)
            {
                enemylooked3 = true;

                timeForAIToLookAround = 0.0f;
            }
        }

        if (enemylooked1 == true && enemylooked2 == true && enemylooked3 == true &&
            enemyIsPatrolling == true && enemySawPlayer == false)
        {
            enemylooked1 = false;
            enemylooked2 = false;
            enemylooked3 = false;
        }
    }

    void EnemyPatrol2()
    {

    }

    void Enemy1CaughtPlayer()
    {
        enemyIsPatrolling = false;
        enemySawPlayer = true;

        if (enemySawPlayer == true && enemyIsPatrolling == false)
        {
            var towardsPlayer = player.transform.position - transform.position;

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
                Time.deltaTime * 1.0f);

            // Still experimenting with rotation of the enemy light
            //transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(0.0f, 0.0f, transform.rotation.z),
            //Quaternion.LookRotation(towardsPlayer), Time.deltaTime * 45.0f);
        }
    }

    void Enemy2CaughtPlayer()
    {
        enemyIsPatrolling = false;
        enemySawPlayer = true;

        if (enemySawPlayer == true && enemyIsPatrolling == false)
        {
            var towardsPlayer = player.transform.position - transform.position;

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
                Time.deltaTime * 1.0f);

            // Still experimenting with rotation of the enemy light
            //transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(0.0f, 0.0f, transform.rotation.z),
            //Quaternion.LookRotation(towardsPlayer), Time.deltaTime * 45.0f);
        }
    }

    void Enemy3CaughtPlayer()
    {
        enemyIsPatrolling = false;
        enemySawPlayer = true;

        if (enemySawPlayer == true && enemyIsPatrolling == false)
        {
            var towardsPlayer = player.transform.position - transform.position;

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
                Time.deltaTime * 1.0f);

            // Still experimenting with rotation of the enemy light
            //transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(0.0f, 0.0f, transform.rotation.z),
            //Quaternion.LookRotation(towardsPlayer), Time.deltaTime * 45.0f);
        }
    }

    // Show the game over whenever the player is way too close to the enemy
    void ShowGameOverScreen()
    {
        // If the player and enemy are way too close, load the game over scene for Level 1
        if (Vector3.Distance(transform.position, player.transform.position) <= 0.0f &&
            Player.currentScene.name == "Level1")
        {
            MainMenuScript.completedLevel1 = false;

            SceneManager.LoadScene("GameOverLevel1");
        }

        // If the player and enemy are way too close, load the game over scene for Level 2
        if (Vector3.Distance(transform.position, player.transform.position) <= 0.0f &&
            Player.currentScene.name == "Level2")
        {
            MainMenuScript.completedLevel2 = false;

            SceneManager.LoadScene("GameOverLevel2");
        }

        // If the player and enemy are way too close, load the game over scene for Level 3
        if (Vector3.Distance(transform.position, player.transform.position) <= 0.0f &&
            Player.currentScene.name == "Level3")
        {
            SceneManager.LoadScene("GameOverLevel3");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // If the enemy is being collided by the player, trigger some enemy dialogue
        if (collision.gameObject.name == "Player")
        {
            // Set the enemy saw player to true so that the enemy will chase the player around until they're at a safe distance
            enemySawPlayer = true;

            if (enemyLineIndex == 0)
            {
                enemyLine1.Play();
                enemyLine2.Stop();
                enemyLine3.Stop();
                enemyLine4.Stop();
                enemyLine5.Stop();
                enemyLine6.Stop();
                enemyLine7.Stop();
                enemyLine8.Stop();
                enemyLine9.Stop();

                enemyLine1.transform.position = transform.position;
            }

            if (enemyLineIndex == 1)
            {
                enemyLine1.Stop();
                enemyLine2.Play();
                enemyLine3.Stop();
                enemyLine4.Stop();
                enemyLine5.Stop();
                enemyLine6.Stop();
                enemyLine7.Stop();
                enemyLine8.Stop();
                enemyLine9.Stop();

                enemyLine2.transform.position = transform.position;
            }

            if (enemyLineIndex == 2)
            {
                enemyLine1.Stop();
                enemyLine2.Stop();
                enemyLine3.Play();
                enemyLine4.Stop();
                enemyLine5.Stop();
                enemyLine6.Stop();
                enemyLine7.Stop();
                enemyLine8.Stop();
                enemyLine9.Stop();

                enemyLine3.transform.position = transform.position;
            }

            if (enemyLineIndex == 3)
            {
                enemyLine1.Stop();
                enemyLine2.Stop();
                enemyLine3.Stop();
                enemyLine4.Play();
                enemyLine5.Stop();
                enemyLine6.Stop();
                enemyLine7.Stop();
                enemyLine8.Stop();
                enemyLine9.Stop();

                enemyLine4.transform.position = transform.position;
            }

            if (enemyLineIndex == 4)
            {
                enemyLine1.Stop();
                enemyLine2.Stop();
                enemyLine3.Stop();
                enemyLine4.Stop();
                enemyLine5.Play();
                enemyLine6.Stop();
                enemyLine7.Stop();
                enemyLine8.Stop();
                enemyLine9.Stop();

                enemyLine5.transform.position = transform.position;
            }

            if (enemyLineIndex == 5)
            {
                enemyLine1.Stop();
                enemyLine2.Stop();
                enemyLine3.Stop();
                enemyLine4.Stop();
                enemyLine5.Stop();
                enemyLine6.Play();
                enemyLine7.Stop();
                enemyLine8.Stop();
                enemyLine9.Stop();

                enemyLine6.transform.position = transform.position;
            }

            if (enemyLineIndex == 6)
            {
                enemyLine1.Stop();
                enemyLine2.Stop();
                enemyLine3.Stop();
                enemyLine4.Stop();
                enemyLine5.Stop();
                enemyLine6.Stop();
                enemyLine7.Play();
                enemyLine8.Stop();
                enemyLine9.Stop();

                enemyLine7.transform.position = transform.position;
            }

            if (enemyLineIndex == 7)
            {
                enemyLine1.Stop();
                enemyLine2.Stop();
                enemyLine3.Stop();
                enemyLine4.Stop();
                enemyLine5.Stop();
                enemyLine6.Stop();
                enemyLine7.Stop();
                enemyLine8.Play();
                enemyLine9.Stop();

                enemyLine8.transform.position = transform.position;
            }

            if (enemyLineIndex == 8)
            {
                enemyLine1.Stop();
                enemyLine2.Stop();
                enemyLine3.Stop();
                enemyLine4.Stop();
                enemyLine5.Stop();
                enemyLine6.Stop();
                enemyLine7.Stop();
                enemyLine8.Stop();
                enemyLine9.Play();

                enemyLine9.transform.position = transform.position;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Set the enemy saw player to true so that the enemy will chase the player around until they're at a safe distance
            //enemySawPlayer = true;
        }
    }
}
