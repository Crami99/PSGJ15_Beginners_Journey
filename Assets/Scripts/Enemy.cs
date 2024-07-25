using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private int enemyLineIndex;
    private int enemyLostSightOfPlayerLineIndex;

    private AudioSource enemySawPlayerLine1, enemySawPlayerLine2, enemySawPlayerLine3, enemySawPlayerLine4,
        enemySawPlayerLine5, enemySawPlayerLine6, enemySawPlayerLine7, enemySawPlayerLine8, enemySawPlayerLine9;

    private AudioSource enemyLostPlayerLine1, enemyLostPlayerLine2, enemyLostPlayerLine3, enemyLostPlayerLine4,
        enemyLostPlayerLine5, enemyLostPlayerLine6, enemyLostPlayerLine7, enemyLostPlayerLine8, enemyLostPlayerLine9;

    public Transform[] patrolPoints;
    private int patrolPointIndex;

    private float timeToLookAround;

    private GameObject player;

    public static bool isEnemyPatrolling;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        isEnemyPatrolling = true;
        patrolPointIndex = 0;

        enemySawPlayerLine1 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine1").GetComponent<AudioSource>();
        enemySawPlayerLine2 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine2").GetComponent<AudioSource>();
        enemySawPlayerLine3 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine3").GetComponent<AudioSource>();
        enemySawPlayerLine4 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine4").GetComponent<AudioSource>();
        enemySawPlayerLine5 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine5").GetComponent<AudioSource>();
        enemySawPlayerLine6 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine6").GetComponent<AudioSource>();
        enemySawPlayerLine7 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine7").GetComponent<AudioSource>();
        enemySawPlayerLine8 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine8").GetComponent<AudioSource>();
        enemySawPlayerLine9 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine9").GetComponent<AudioSource>();

        enemyLostPlayerLine1 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine1").GetComponent<AudioSource>();
        enemyLostPlayerLine2 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine2").GetComponent<AudioSource>();
        enemyLostPlayerLine3 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine3").GetComponent<AudioSource>();
        enemyLostPlayerLine4 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine4").GetComponent<AudioSource>();
        enemyLostPlayerLine5 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine5").GetComponent<AudioSource>();
        enemyLostPlayerLine6 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine6").GetComponent<AudioSource>();
        enemyLostPlayerLine7 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine7").GetComponent<AudioSource>();
        enemyLostPlayerLine8 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine8").GetComponent<AudioSource>();
        enemyLostPlayerLine9 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine9").GetComponent<AudioSource>();

        enemySawPlayerLine1.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemySawPlayerLine2.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemySawPlayerLine3.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemySawPlayerLine4.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemySawPlayerLine5.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemySawPlayerLine6.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemySawPlayerLine7.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemySawPlayerLine8.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemySawPlayerLine9.volume = PlayerPrefs.GetFloat("SFXSliderValue");

        enemyLostPlayerLine1.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemyLostPlayerLine2.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemyLostPlayerLine3.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemyLostPlayerLine4.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemyLostPlayerLine5.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemyLostPlayerLine6.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemyLostPlayerLine7.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemyLostPlayerLine8.volume = PlayerPrefs.GetFloat("SFXSliderValue");
        enemyLostPlayerLine9.volume = PlayerPrefs.GetFloat("SFXSliderValue");
    }

    // Update is called once per frame
    void Update()
    {
        enemyLineIndex = Random.Range(0, 9);
        enemyLostSightOfPlayerLineIndex = Random.Range(0, 9);

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

            enemyLostPlayerLine1.Stop();
            enemyLostPlayerLine2.Stop();
            enemyLostPlayerLine3.Stop();
            enemyLostPlayerLine4.Stop();
            enemyLostPlayerLine5.Stop();
            enemyLostPlayerLine6.Stop();
            enemyLostPlayerLine7.Stop();
            enemyLostPlayerLine8.Stop();
            enemyLostPlayerLine9.Stop();

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

            enemyLostPlayerLine1.Stop();
            enemyLostPlayerLine2.Stop();
            enemyLostPlayerLine3.Stop();
            enemyLostPlayerLine4.Stop();
            enemyLostPlayerLine5.Stop();
            enemyLostPlayerLine6.Stop();
            enemyLostPlayerLine7.Stop();
            enemyLostPlayerLine8.Stop();
            enemyLostPlayerLine9.Stop();

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

            enemyLostPlayerLine1.Stop();
            enemyLostPlayerLine2.Stop();
            enemyLostPlayerLine3.Stop();
            enemyLostPlayerLine4.Stop();
            enemyLostPlayerLine5.Stop();
            enemyLostPlayerLine6.Stop();
            enemyLostPlayerLine7.Stop();
            enemyLostPlayerLine8.Stop();
            enemyLostPlayerLine9.Stop();

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

            enemyLostPlayerLine1.Stop();
            enemyLostPlayerLine2.Stop();
            enemyLostPlayerLine3.Stop();
            enemyLostPlayerLine4.Stop();
            enemyLostPlayerLine5.Stop();
            enemyLostPlayerLine6.Stop();
            enemyLostPlayerLine7.Stop();
            enemyLostPlayerLine8.Stop();
            enemyLostPlayerLine9.Stop();

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

            enemyLostPlayerLine1.Stop();
            enemyLostPlayerLine2.Stop();
            enemyLostPlayerLine3.Stop();
            enemyLostPlayerLine4.Stop();
            enemyLostPlayerLine5.Stop();
            enemyLostPlayerLine6.Stop();
            enemyLostPlayerLine7.Stop();
            enemyLostPlayerLine8.Stop();
            enemyLostPlayerLine9.Stop();


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

            enemyLostPlayerLine1.Stop();
            enemyLostPlayerLine2.Stop();
            enemyLostPlayerLine3.Stop();
            enemyLostPlayerLine4.Stop();
            enemyLostPlayerLine5.Stop();
            enemyLostPlayerLine6.Stop();
            enemyLostPlayerLine7.Stop();
            enemyLostPlayerLine8.Stop();
            enemyLostPlayerLine9.Stop();

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

            enemyLostPlayerLine1.Stop();
            enemyLostPlayerLine2.Stop();
            enemyLostPlayerLine3.Stop();
            enemyLostPlayerLine4.Stop();
            enemyLostPlayerLine5.Stop();
            enemyLostPlayerLine6.Stop();
            enemyLostPlayerLine7.Stop();
            enemyLostPlayerLine8.Stop();
            enemyLostPlayerLine9.Stop();

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

            enemyLostPlayerLine1.Stop();
            enemyLostPlayerLine2.Stop();
            enemyLostPlayerLine3.Stop();
            enemyLostPlayerLine4.Stop();
            enemyLostPlayerLine5.Stop();
            enemyLostPlayerLine6.Stop();
            enemyLostPlayerLine7.Stop();
            enemyLostPlayerLine8.Stop();
            enemyLostPlayerLine9.Stop();

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

            enemyLostPlayerLine1.Stop();
            enemyLostPlayerLine2.Stop();
            enemyLostPlayerLine3.Stop();
            enemyLostPlayerLine4.Stop();
            enemyLostPlayerLine5.Stop();
            enemyLostPlayerLine6.Stop();
            enemyLostPlayerLine7.Stop();
            enemyLostPlayerLine8.Stop();
            enemyLostPlayerLine9.Stop();

            enemySawPlayerLine9.transform.position = transform.position;
        }
    }

    private void PlayEnemyLostPlayerLines()
    {
        if (enemyLostSightOfPlayerLineIndex == 0)
        {
            if (enemySawPlayerLine1 != null && enemySawPlayerLine2 != null && enemySawPlayerLine3 != null &&
                enemySawPlayerLine4 != null && enemySawPlayerLine5 != null && enemySawPlayerLine6 != null &&
                enemySawPlayerLine7 != null && enemySawPlayerLine8 != null && enemySawPlayerLine9 != null)
            {
                enemySawPlayerLine1.Stop();
                enemySawPlayerLine2.Stop();
                enemySawPlayerLine3.Stop();
                enemySawPlayerLine4.Stop();
                enemySawPlayerLine5.Stop();
                enemySawPlayerLine6.Stop();
                enemySawPlayerLine7.Stop();
                enemySawPlayerLine8.Stop();
                enemySawPlayerLine9.Stop();
            }

            if (enemyLostPlayerLine1 != null && enemyLostPlayerLine2 != null && enemyLostPlayerLine3 != null &&
                enemyLostPlayerLine4 != null && enemyLostPlayerLine5 != null && enemyLostPlayerLine6 != null &&
                enemyLostPlayerLine7 != null && enemyLostPlayerLine8 != null && enemyLostPlayerLine9 != null)
            {
                enemyLostPlayerLine1.Play();
                enemyLostPlayerLine2.Stop();
                enemyLostPlayerLine3.Stop();
                enemyLostPlayerLine4.Stop();
                enemyLostPlayerLine5.Stop();
                enemyLostPlayerLine6.Stop();
                enemyLostPlayerLine7.Stop();
                enemyLostPlayerLine8.Stop();
                enemyLostPlayerLine9.Stop();

                enemyLostPlayerLine1.transform.position = transform.position;
            }
        }

        if (enemyLostSightOfPlayerLineIndex == 1)
        {
            if (enemySawPlayerLine1 != null && enemySawPlayerLine2 != null && enemySawPlayerLine3 != null &&
                enemySawPlayerLine4 != null && enemySawPlayerLine5 != null && enemySawPlayerLine6 != null &&
                enemySawPlayerLine7 != null && enemySawPlayerLine8 != null && enemySawPlayerLine9 != null)
            {
                enemySawPlayerLine1.Stop();
                enemySawPlayerLine2.Stop();
                enemySawPlayerLine3.Stop();
                enemySawPlayerLine4.Stop();
                enemySawPlayerLine5.Stop();
                enemySawPlayerLine6.Stop();
                enemySawPlayerLine7.Stop();
                enemySawPlayerLine8.Stop();
                enemySawPlayerLine9.Stop();
            }

            if (enemyLostPlayerLine1 != null && enemyLostPlayerLine2 != null && enemyLostPlayerLine3 != null &&
                enemyLostPlayerLine4 != null && enemyLostPlayerLine5 != null && enemyLostPlayerLine6 != null &&
                enemyLostPlayerLine7 != null && enemyLostPlayerLine8 != null && enemyLostPlayerLine9 != null)
            {
                enemyLostPlayerLine1.Stop();
                enemyLostPlayerLine2.Play();
                enemyLostPlayerLine3.Stop();
                enemyLostPlayerLine4.Stop();
                enemyLostPlayerLine5.Stop();
                enemyLostPlayerLine6.Stop();
                enemyLostPlayerLine7.Stop();
                enemyLostPlayerLine8.Stop();
                enemyLostPlayerLine9.Stop();

                enemyLostPlayerLine2.transform.position = transform.position;
            }
        }

        if (enemyLostSightOfPlayerLineIndex == 2)
        {
            if (enemySawPlayerLine1 != null && enemySawPlayerLine2 != null && enemySawPlayerLine3 != null &&
                enemySawPlayerLine4 != null && enemySawPlayerLine5 != null && enemySawPlayerLine6 != null &&
                enemySawPlayerLine7 != null && enemySawPlayerLine8 != null && enemySawPlayerLine9 != null)
            {
                enemySawPlayerLine1.Stop();
                enemySawPlayerLine2.Stop();
                enemySawPlayerLine3.Stop();
                enemySawPlayerLine4.Stop();
                enemySawPlayerLine5.Stop();
                enemySawPlayerLine6.Stop();
                enemySawPlayerLine7.Stop();
                enemySawPlayerLine8.Stop();
                enemySawPlayerLine9.Stop();
            }

            if (enemyLostPlayerLine1 != null && enemyLostPlayerLine2 != null && enemyLostPlayerLine3 != null &&
                enemyLostPlayerLine4 != null && enemyLostPlayerLine5 != null && enemyLostPlayerLine6 != null &&
                enemyLostPlayerLine7 != null && enemyLostPlayerLine8 != null && enemyLostPlayerLine9 != null)
            {
                enemyLostPlayerLine1.Stop();
                enemyLostPlayerLine2.Stop();
                enemyLostPlayerLine3.Play();
                enemyLostPlayerLine4.Stop();
                enemyLostPlayerLine5.Stop();
                enemyLostPlayerLine6.Stop();
                enemyLostPlayerLine7.Stop();
                enemyLostPlayerLine8.Stop();
                enemyLostPlayerLine9.Stop();

                enemyLostPlayerLine3.transform.position = transform.position;
            }
        }

        if (enemyLostSightOfPlayerLineIndex == 3)
        {
            if (enemySawPlayerLine1 != null && enemySawPlayerLine2 != null && enemySawPlayerLine3 != null &&
                enemySawPlayerLine4 != null && enemySawPlayerLine5 != null && enemySawPlayerLine6 != null &&
                enemySawPlayerLine7 != null && enemySawPlayerLine8 != null && enemySawPlayerLine9 != null)
            {
                enemySawPlayerLine1.Stop();
                enemySawPlayerLine2.Stop();
                enemySawPlayerLine3.Stop();
                enemySawPlayerLine4.Stop();
                enemySawPlayerLine5.Stop();
                enemySawPlayerLine6.Stop();
                enemySawPlayerLine7.Stop();
                enemySawPlayerLine8.Stop();
                enemySawPlayerLine9.Stop();
            }

            if (enemyLostPlayerLine1 != null && enemyLostPlayerLine2 != null && enemyLostPlayerLine3 != null &&
                enemyLostPlayerLine4 != null && enemyLostPlayerLine5 != null && enemyLostPlayerLine6 != null &&
                enemyLostPlayerLine7 != null && enemyLostPlayerLine8 != null && enemyLostPlayerLine9 != null)
            {
                enemyLostPlayerLine1.Stop();
                enemyLostPlayerLine2.Stop();
                enemyLostPlayerLine3.Stop();
                enemyLostPlayerLine4.Play();
                enemyLostPlayerLine5.Stop();
                enemyLostPlayerLine6.Stop();
                enemyLostPlayerLine7.Stop();
                enemyLostPlayerLine8.Stop();
                enemyLostPlayerLine9.Stop();

                enemyLostPlayerLine4.transform.position = transform.position;
            }
        }

        if (enemyLostSightOfPlayerLineIndex == 4)
        {
            if (enemySawPlayerLine1 != null && enemySawPlayerLine2 != null && enemySawPlayerLine3 != null &&
                enemySawPlayerLine4 != null && enemySawPlayerLine5 != null && enemySawPlayerLine6 != null &&
                enemySawPlayerLine7 != null && enemySawPlayerLine8 != null && enemySawPlayerLine9 != null)
            {
                enemySawPlayerLine1.Stop();
                enemySawPlayerLine2.Stop();
                enemySawPlayerLine3.Stop();
                enemySawPlayerLine4.Stop();
                enemySawPlayerLine5.Stop();
                enemySawPlayerLine6.Stop();
                enemySawPlayerLine7.Stop();
                enemySawPlayerLine8.Stop();
                enemySawPlayerLine9.Stop();
            }

            if (enemyLostPlayerLine1 != null && enemyLostPlayerLine2 != null && enemyLostPlayerLine3 != null &&
                enemyLostPlayerLine4 != null && enemyLostPlayerLine5 != null && enemyLostPlayerLine6 != null &&
                enemyLostPlayerLine7 != null && enemyLostPlayerLine8 != null && enemyLostPlayerLine9 != null)
            {
                enemyLostPlayerLine1.Stop();
                enemyLostPlayerLine2.Stop();
                enemyLostPlayerLine3.Stop();
                enemyLostPlayerLine4.Stop();
                enemyLostPlayerLine5.Play();
                enemyLostPlayerLine6.Stop();
                enemyLostPlayerLine7.Stop();
                enemyLostPlayerLine8.Stop();
                enemyLostPlayerLine9.Stop();

                enemyLostPlayerLine5.transform.position = transform.position;
            }
        }

        if (enemyLostSightOfPlayerLineIndex == 5)
        {
            if (enemySawPlayerLine1 != null && enemySawPlayerLine2 != null && enemySawPlayerLine3 != null &&
                enemySawPlayerLine4 != null && enemySawPlayerLine5 != null && enemySawPlayerLine6 != null &&
                enemySawPlayerLine7 != null && enemySawPlayerLine8 != null && enemySawPlayerLine9 != null)
            {
                enemySawPlayerLine1.Stop();
                enemySawPlayerLine2.Stop();
                enemySawPlayerLine3.Stop();
                enemySawPlayerLine4.Stop();
                enemySawPlayerLine5.Stop();
                enemySawPlayerLine6.Stop();
                enemySawPlayerLine7.Stop();
                enemySawPlayerLine8.Stop();
                enemySawPlayerLine9.Stop();
            }

            if (enemyLostPlayerLine1 != null && enemyLostPlayerLine2 != null && enemyLostPlayerLine3 != null &&
                enemyLostPlayerLine4 != null && enemyLostPlayerLine5 != null && enemyLostPlayerLine6 != null &&
                enemyLostPlayerLine7 != null && enemyLostPlayerLine8 != null && enemyLostPlayerLine9 != null)
            {
                enemyLostPlayerLine1.Stop();
                enemyLostPlayerLine2.Stop();
                enemyLostPlayerLine3.Stop();
                enemyLostPlayerLine4.Stop();
                enemyLostPlayerLine5.Stop();
                enemyLostPlayerLine6.Play();
                enemyLostPlayerLine7.Stop();
                enemyLostPlayerLine8.Stop();
                enemyLostPlayerLine9.Stop();

                enemyLostPlayerLine6.transform.position = transform.position;
            }
        }

        if (enemyLostSightOfPlayerLineIndex == 6)
        {
            if (enemySawPlayerLine1 != null && enemySawPlayerLine2 != null && enemySawPlayerLine3 != null &&
                enemySawPlayerLine4 != null && enemySawPlayerLine5 != null && enemySawPlayerLine6 != null &&
                enemySawPlayerLine7 != null && enemySawPlayerLine8 != null && enemySawPlayerLine9 != null)
            {
                enemySawPlayerLine1.Stop();
                enemySawPlayerLine2.Stop();
                enemySawPlayerLine3.Stop();
                enemySawPlayerLine4.Stop();
                enemySawPlayerLine5.Stop();
                enemySawPlayerLine6.Stop();
                enemySawPlayerLine7.Stop();
                enemySawPlayerLine8.Stop();
                enemySawPlayerLine9.Stop();
            }

            if (enemyLostPlayerLine1 != null && enemyLostPlayerLine2 != null && enemyLostPlayerLine3 != null &&
                enemyLostPlayerLine4 != null && enemyLostPlayerLine5 != null && enemyLostPlayerLine6 != null &&
                enemyLostPlayerLine7 != null && enemyLostPlayerLine8 != null && enemyLostPlayerLine9 != null)
            {
                enemyLostPlayerLine1.Stop();
                enemyLostPlayerLine2.Stop();
                enemyLostPlayerLine3.Stop();
                enemyLostPlayerLine4.Stop();
                enemyLostPlayerLine5.Stop();
                enemyLostPlayerLine6.Stop();
                enemyLostPlayerLine7.Play();
                enemyLostPlayerLine8.Stop();
                enemyLostPlayerLine9.Stop();

                enemyLostPlayerLine7.transform.position = transform.position;
            }
        }

        if (enemyLostSightOfPlayerLineIndex == 7)
        {
            if (enemySawPlayerLine1 != null && enemySawPlayerLine2 != null && enemySawPlayerLine3 != null &&
                enemySawPlayerLine4 != null && enemySawPlayerLine5 != null && enemySawPlayerLine6 != null &&
                enemySawPlayerLine7 != null && enemySawPlayerLine8 != null && enemySawPlayerLine9 != null)
            {
                enemySawPlayerLine1.Stop();
                enemySawPlayerLine2.Stop();
                enemySawPlayerLine3.Stop();
                enemySawPlayerLine4.Stop();
                enemySawPlayerLine5.Stop();
                enemySawPlayerLine6.Stop();
                enemySawPlayerLine7.Stop();
                enemySawPlayerLine8.Stop();
                enemySawPlayerLine9.Stop();
            }

            if (enemyLostPlayerLine1 != null && enemyLostPlayerLine2 != null && enemyLostPlayerLine3 != null &&
                enemyLostPlayerLine4 != null && enemyLostPlayerLine5 != null && enemyLostPlayerLine6 != null &&
                enemyLostPlayerLine7 != null && enemyLostPlayerLine8 != null && enemyLostPlayerLine9 != null)
            {
                enemyLostPlayerLine1.Stop();
                enemyLostPlayerLine2.Stop();
                enemyLostPlayerLine3.Stop();
                enemyLostPlayerLine4.Stop();
                enemyLostPlayerLine5.Stop();
                enemyLostPlayerLine6.Stop();
                enemyLostPlayerLine7.Stop();
                enemyLostPlayerLine8.Play();
                enemyLostPlayerLine9.Stop();

                enemyLostPlayerLine8.transform.position = transform.position;
            }
        }

        if (enemyLostSightOfPlayerLineIndex == 8)
        {
            if (enemySawPlayerLine1 != null && enemySawPlayerLine2 != null && enemySawPlayerLine3 != null &&
                enemySawPlayerLine4 != null && enemySawPlayerLine5 != null && enemySawPlayerLine6 != null &&
                enemySawPlayerLine7 != null && enemySawPlayerLine8 != null && enemySawPlayerLine9 != null)
            {
                enemySawPlayerLine1.Stop();
                enemySawPlayerLine2.Stop();
                enemySawPlayerLine3.Stop();
                enemySawPlayerLine4.Stop();
                enemySawPlayerLine5.Stop();
                enemySawPlayerLine6.Stop();
                enemySawPlayerLine7.Stop();
                enemySawPlayerLine8.Stop();
                enemySawPlayerLine9.Stop();
            }

            if (enemyLostPlayerLine1 != null && enemyLostPlayerLine2 != null && enemyLostPlayerLine3 != null &&
                enemyLostPlayerLine4 != null && enemyLostPlayerLine5 != null && enemyLostPlayerLine6 != null &&
                enemyLostPlayerLine7 != null && enemyLostPlayerLine8 != null && enemyLostPlayerLine9 != null)
            {
                enemyLostPlayerLine1.Stop();
                enemyLostPlayerLine2.Stop();
                enemyLostPlayerLine3.Stop();
                enemyLostPlayerLine4.Stop();
                enemyLostPlayerLine5.Stop();
                enemyLostPlayerLine6.Stop();
                enemyLostPlayerLine7.Stop();
                enemyLostPlayerLine8.Stop();
                enemyLostPlayerLine9.Play();

                enemyLostPlayerLine9.transform.position = transform.position;
            }
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
