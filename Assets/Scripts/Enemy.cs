using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Transform[] patrolPoints;
    private int patrolPointIndex;

    private float timeToLookAround;

    private GameObject player;

    private Animator enemyAnimator;

    public bool isEnemyPatrolling;

    AudioSource audioSrc;
    List<string> spottedClips;
    List<string> lostClips;

    // Reference to the different enemy health and shield slider bars
    private Slider enemyHealthBar1;
    private Slider enemyShieldBar1;

    private Slider enemyHealthBar2;
    private Slider enemyShieldBar2;

    private Slider enemyHealthBar3;
    private Slider enemyShieldBar3;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        rigidbody = GetComponent<Rigidbody2D>();

        enemyHealthBar1 = GameObject.Find("EnemyHealthBar1").GetComponentInChildren<Slider>();
        enemyShieldBar1 = GameObject.Find("EnemyShieldBar1").GetComponentInChildren<Slider>();

        enemyHealthBar2 = GameObject.Find("EnemyHealthBar2").GetComponentInChildren<Slider>();
        enemyShieldBar2 = GameObject.Find("EnemyShieldBar2").GetComponentInChildren<Slider>();

        enemyHealthBar3 = GameObject.Find("EnemyHealthBar3").GetComponentInChildren<Slider>();
        enemyShieldBar3 = GameObject.Find("EnemyShieldBar3").GetComponentInChildren<Slider>();

        enemyAnimator = GetComponent<Animator>();

        isEnemyPatrolling = true;
        patrolPointIndex = 0;

        audioSrc = gameObject.GetComponent<AudioSource>();

        if(PlayerPrefs.GetFloat("SFXSliderValue") != null){
            audioSrc.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        }else{
            audioSrc.volume = 100f;
        }

        //to add new sounds simply place them in the correct folder and add thier name to the list
        spottedClips = new List<string> {"ComeHere", "ComeToDaddy", "Deathwarrant", "DieTonight", "GetReady", "ISeeYou", "TakeYouDown", "There", "YouThought"};
        lostClips = new List<string> {"Come", "ComeBack", "ComeOut", "DamnIt", "LostHim", "TimeToLook", "Where", "WillFind", "YouThink"};

        //get patrolPoints
        int pointCount = gameObject.transform.parent.Find("PatrolPoints").childCount;

        patrolPoints = new Transform[pointCount];

        for(int i = 0; i < pointCount; i++){
            patrolPoints[i] = gameObject.transform.parent.Find("PatrolPoints").GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPatrolling();

        // For now, destroy the 1st enemy if their health and shield values are at 0
        if (enemyHealthBar1.value <= 0.0f && enemyShieldBar1.value <= 0.0f)
        {
            GameObject enemy1 = GameObject.Find("PatrolingEnemy");
            Destroy(enemy1);
        }

        // For now, destroy the 2nd enemy if their health and shield values are at 0
        if (enemyHealthBar2.value <= 0.0f && enemyShieldBar2.value <= 0.0f)
        {
            GameObject enemy2 = GameObject.Find("PatrolingEnemy (1)");
            Destroy(enemy2);
        }

        // For now, destroy the 3rd enemy if their health and shield values are at 0
        if (enemyHealthBar3.value <= 0.0f && enemyShieldBar3.value <= 0.0f)
        {
            GameObject enemy3 = GameObject.Find("PatrolingEnemy (2)");
            Destroy(enemy3);
        }
    }

    private void EnemyPatrolling()
    {
        if (isEnemyPatrolling == true)
        {
            if(transform.position != patrolPoints[patrolPointIndex].transform.position){
                //move towards patrolPoint
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[patrolPointIndex].transform.position, Time.deltaTime * 5.0f);
            }else{
                if(timeToLookAround >= 2f){
                    //wait
                    timeToLookAround += Time.deltaTime;
                }else{
                    timeToLookAround = 0f;
                    patrolPointIndex ++;
                    patrolPointIndex = patrolPointIndex % 4;
                }
            }
        }
    }

    private void PlayEnemyCaughtPlayerLines()
    {
        //if the enemy is not currently playing a sound, play a sound
        if(!audioSrc.isPlaying)
        {
            string path = "SoundEffects/Enemy/Spotted/";

            int soundIndex = Random.Range(0, spottedClips.Count);

            audioSrc.clip = Resources.Load<AudioClip>(path + spottedClips[soundIndex]);
            audioSrc.Play();
        }
    }
        

    private void PlayEnemyLostPlayerLines()
    {
        //if the enemy is not currently playing a sound, play a sound
        if(!audioSrc.isPlaying || audioSrc.isPlaying)
        {
            string path = "SoundEffects/Enemy/Lost/";

            int soundIndex = Random.Range(0, lostClips.Count);

            audioSrc.clip = Resources.Load<AudioClip>(path + lostClips[soundIndex]);
            audioSrc.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayEnemyCaughtPlayerLines();

            isEnemyPatrolling = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isEnemyPatrolling == false)
        {
            enemyAnimator.Play("EnemyAttack");

            // If the enemy is not close enough to the player, then move towards the player
            if (Vector3.Distance(transform.position, player.transform.position) > 4.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
                Time.deltaTime * 10.0f);
            }

            // If the enemy gets way too close to the player, then stop the enemy from moving
            else if (Vector3.Distance(transform.position, player.transform.position) <= 1.0f)
            {
                transform.position = transform.position;
            }
        }

        // If enemy 1 has collided with the player
        if (gameObject.name == "Enemy1" && collision.gameObject.tag == "Player")
        {
            if (enemyShieldBar1.value > 0)
            {
                enemyShieldBar1.value = enemyShieldBar1.value - 15.0f * Time.deltaTime;
            }
            else
            {
                enemyHealthBar1.value = enemyHealthBar1.value - 30.0f * Time.deltaTime;
            }
        }

        // If enemy 2 has collided with the player
        else if (gameObject.name == "Enemy2" && collision.gameObject.tag == "Player")
        {
            if (enemyShieldBar2.value > 0)
            {
                enemyShieldBar2.value = enemyShieldBar2.value - 15.0f * Time.deltaTime;
            }
            else
            {
                enemyHealthBar2.value = enemyHealthBar2.value - 30.0f * Time.deltaTime;
            }
        }

        // If enemy 3 has collided with the player
        else if (gameObject.name == "Enemy3" && collision.gameObject.tag == "Player")
        {
            if (enemyShieldBar3.value > 0)
            {
                enemyShieldBar3.value = enemyShieldBar3.value - 15.0f * Time.deltaTime;
            }
            else
            {
                enemyHealthBar3.value = enemyHealthBar3.value - 30.0f * Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayEnemyLostPlayerLines();

            isEnemyPatrolling = true;
            enemyAnimator.gameObject.GetComponent<Animator>().enabled = false;
        }
    }
}
