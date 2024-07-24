using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int enemyLineIndex;
    private int enemyLostSightOfPlayerLineIndex;

    private AudioSource enemySawPlayerLine1, enemySawPlayerLine2, enemySawPlayerLine3, enemySawPlayerLine4,
        enemySawPlayerLine5, enemySawPlayerLine6, enemySawPlayerLine7, enemySawPlayerLine8, enemySawPlayerLine9;

    private AudioSource enemyLostPlayerLine1, enemyLostPlayerLine2, enemyLostPlayerLine3, enemyLostPlayerLine4,
        enemyLostPlayerLine5, enemyLostPlayerLine6, enemyLostPlayerLine7, enemyLostPlayerLine8, enemyLostPlayerLine9;

    // Start is called before the first frame update
    void Start()
    {
        enemySawPlayerLine1 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine1").GetComponent<AudioSource>();
        enemySawPlayerLine2 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine2").GetComponent<AudioSource>();
        enemySawPlayerLine3 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine3").GetComponent<AudioSource>();
        enemySawPlayerLine4 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine4").GetComponent<AudioSource>();
        enemySawPlayerLine5 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine5").GetComponent<AudioSource>();
        enemySawPlayerLine6 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine6").GetComponent<AudioSource>();
        enemySawPlayerLine7 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine7").GetComponent<AudioSource>();
        enemySawPlayerLine8 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine8").GetComponent<AudioSource>();
        enemySawPlayerLine9 = GameObject.Find("EnemySawPlayerSounds/EnemySawPlayerLine9").GetComponent<AudioSource>();

        /*enemySawPlayerLine1.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine2.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine3.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine4.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine5.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine6.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine7.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine8.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemySawPlayerLine9.volume = OptionsMenuScript.sfxVolumeSlider.value;*/

        enemyLostPlayerLine1 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine1").GetComponent<AudioSource>();
        enemyLostPlayerLine2 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine2").GetComponent<AudioSource>();
        enemyLostPlayerLine3 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine3").GetComponent<AudioSource>();
        enemyLostPlayerLine4 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine4").GetComponent<AudioSource>();
        enemyLostPlayerLine5 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine5").GetComponent<AudioSource>();
        enemyLostPlayerLine6 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine6").GetComponent<AudioSource>();
        enemyLostPlayerLine7 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine7").GetComponent<AudioSource>();
        enemyLostPlayerLine8 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine8").GetComponent<AudioSource>();
        enemyLostPlayerLine9 = GameObject.Find("EnemyLostSightSounds/EnemyLostSightLine9").GetComponent<AudioSource>();

        /*enemyLostPlayerLine1.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLostPlayerLine2.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLostPlayerLine3.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLostPlayerLine4.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLostPlayerLine5.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLostPlayerLine6.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLostPlayerLine7.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLostPlayerLine8.volume = OptionsMenuScript.sfxVolumeSlider.value;
        enemyLostPlayerLine9.volume = OptionsMenuScript.sfxVolumeSlider.value;*/
    }

    // Update is called once per frame
    void Update()
    {
        enemyLineIndex = Random.Range(0, 9);
        enemyLostSightOfPlayerLineIndex = Random.Range(0, 9);
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
            enemySawPlayerLine1.Stop();
            enemySawPlayerLine2.Stop();
            enemySawPlayerLine3.Stop();
            enemySawPlayerLine4.Stop();
            enemySawPlayerLine5.Stop();
            enemySawPlayerLine6.Stop();
            enemySawPlayerLine7.Stop();
            enemySawPlayerLine8.Stop();
            enemySawPlayerLine9.Stop();

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

        if (enemyLostSightOfPlayerLineIndex == 1)
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

        if (enemyLostSightOfPlayerLineIndex == 2)
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

        if (enemyLostSightOfPlayerLineIndex == 3)
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

        if (enemyLostSightOfPlayerLineIndex == 4)
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

        if (enemyLostSightOfPlayerLineIndex == 5)
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

        if (enemyLostSightOfPlayerLineIndex == 6)
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

        if (enemyLostSightOfPlayerLineIndex == 7)
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

        if (enemyLostSightOfPlayerLineIndex == 8)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayEnemyCaughtPlayerLines();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayEnemyLostPlayerLines();
        }
    }
}
