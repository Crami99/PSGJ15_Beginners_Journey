using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int patrolPointIndex;

    private float timeToLookAround;

    private GameObject player;

    public static bool isEnemyPatrolling;

    AudioSource audioSrc;
    List<string> spottedClips;
    List<string> lostClips;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

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

    }

    // Update is called once per frame
    void Update()
    {
        EnemyPatrolling();
    }

    private void EnemyPatrolling()
    {
        if (isEnemyPatrolling == true)
        {
            switch (patrolPointIndex)
            {
                case 0:
                    transform.position = Vector3.MoveTowards(transform.position,
                        patrolPoints[patrolPointIndex].transform.position, Time.deltaTime * 5.0f);

                    timeToLookAround += Time.deltaTime;

                    transform.position = transform.position;


                    if (timeToLookAround >= 2.0f)
                    {
                        timeToLookAround = 0.0f;

                        patrolPointIndex = 1;
                    }

                    break;

                case 1:
                    transform.position = Vector3.MoveTowards(transform.position,
                        patrolPoints[patrolPointIndex].transform.position, Time.deltaTime * 5.0f);

                    timeToLookAround += Time.deltaTime;

                    transform.position = transform.position;

                    if (timeToLookAround >= 2.0f)
                    {
                        timeToLookAround = 0.0f;

                        patrolPointIndex = 2;
                    }

                    break;

                case 2:
                    transform.position = Vector3.MoveTowards(transform.position,
                        patrolPoints[patrolPointIndex].transform.position, Time.deltaTime * 5.0f);

                    timeToLookAround += Time.deltaTime;

                    transform.position = transform.position;

                    if (timeToLookAround >= 2.0f)
                    {
                        timeToLookAround = 0.0f;

                        patrolPointIndex = 3;
                    }

                    break;

                case 3:
                    transform.position = Vector3.MoveTowards(transform.position,
                        patrolPoints[patrolPointIndex].transform.position, Time.deltaTime * 5.0f);

                    timeToLookAround += Time.deltaTime;

                    transform.position = transform.position;


                    if (timeToLookAround >= 2.0f)
                    {
                        timeToLookAround = 0.0f;

                        patrolPointIndex = 0;
                    }

                    break;
            }
        }
    }

    private void PlayEnemyCaughtPlayerLines()
    {
        //if the enemy is not currently playing a sound, play a sound
        if(!audioSrc.isPlaying){
            string path = "SoundEffects/Enemy/Spotted/";

            int soundIndex = Random.Range(0, spottedClips.Count);

            audioSrc.clip = Resources.Load<AudioClip>(path + spottedClips[soundIndex]);
            audioSrc.Play();
        }
    }
        

    private void PlayEnemyLostPlayerLines()
    {
        //if the enemy is not currently playing a sound, play a sound
        if(!audioSrc.isPlaying){
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
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
                Time.deltaTime * 10.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayEnemyLostPlayerLines();

            isEnemyPatrolling = true;
        }
    }
}