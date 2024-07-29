using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Transform[] patrolPoints;
    private int patrolPointIndex;

    private float timeToLookAround;

    private GameObject player;

    public bool isEnemyPatrolling;

    AudioSource audioSrc;
    List<string> spottedClips;
    List<string> lostClips;

    AudioSource enemyFootsteps;
    List<string> footstepClips;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        isEnemyPatrolling = true;
        patrolPointIndex = 0;

        audioSrc = gameObject.GetComponent<AudioSource>();

        audioSrc.volume = PlayerPrefs.GetFloat("SFXSliderValue", 100f);

        enemyFootsteps = GameObject.Find("EnemyFootsteps").GetComponent<AudioSource>();
        enemyFootsteps.volume = PlayerPrefs.GetFloat("SFXSliderValue", 100f);

        footstepClips = new List<string> { "enemy footstep 1", "enemy footstep 2", "enemy footstep 3" };

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
    void FixedUpdate()
    {
        EnemyPatrolling();
    }

    private void EnemyPatrolling()
    {
        if (isEnemyPatrolling == true)
        {
            if(transform.position != patrolPoints[patrolPointIndex].transform.position){
                //move towards patrolPoint

                if (!enemyFootsteps.isPlaying)
                {
                    string path = "SoundEffects/Enemy/Footsteps/";

                    int i = Random.Range(0, footstepClips.Count);

                    enemyFootsteps.clip = Resources.Load<AudioClip>(path + footstepClips[i]);
                    enemyFootsteps.Play();
                }

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
            if (!enemyFootsteps.isPlaying)
            {
                string path = "SoundEffects/Enemy/Footsteps/";

                int i = Random.Range(0, footstepClips.Count);

                enemyFootsteps.clip = Resources.Load<AudioClip>(path + footstepClips[i]);
                enemyFootsteps.Play();
            }

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
