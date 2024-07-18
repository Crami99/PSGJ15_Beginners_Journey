using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AudioSource enemyLine1, enemyLine2, enemyLine3, enemyLine4, enemyLine5, 
        enemyLine6, enemyLine7, enemyLine8, enemyLine9;

    private int enemyLineIndex;

    // Start is called before the first frame update
    void Start()
    {
        enemyLine1 = GameObject.Find("EnemyLine1").GetComponent<AudioSource>();
        enemyLine2 = GameObject.Find("EnemyLine2").GetComponent<AudioSource>();
        enemyLine3 = GameObject.Find("EnemyLine3").GetComponent<AudioSource>();
        enemyLine4 = GameObject.Find("EnemyLine4").GetComponent<AudioSource>();
        enemyLine5 = GameObject.Find("EnemyLine5").GetComponent<AudioSource>();
        enemyLine6 = GameObject.Find("EnemyLine6").GetComponent<AudioSource>();
        enemyLine7 = GameObject.Find("EnemyLine7").GetComponent<AudioSource>();
        enemyLine8 = GameObject.Find("EnemyLine8").GetComponent<AudioSource>();
        enemyLine9 = GameObject.Find("EnemyLine9").GetComponent<AudioSource>();


        /*if (PlayerPrefs.GetFloat("SFXSliderValue") == OptionsMenuScript.sfxVolumeSlider.value)
        {
            enemyLine1.volume = OptionsMenuScript.sfxVolumeSlider.value;
            enemyLine2.volume = OptionsMenuScript.sfxVolumeSlider.value;
            enemyLine3.volume = OptionsMenuScript.sfxVolumeSlider.value;
            enemyLine4.volume = OptionsMenuScript.sfxVolumeSlider.value;
            enemyLine5.volume = OptionsMenuScript.sfxVolumeSlider.value;
            enemyLine6.volume = OptionsMenuScript.sfxVolumeSlider.value;
            enemyLine7.volume = OptionsMenuScript.sfxVolumeSlider.value;
            enemyLine8.volume = OptionsMenuScript.sfxVolumeSlider.value;
            enemyLine9.volume = OptionsMenuScript.sfxVolumeSlider.value;
        }*/

        enemyLineIndex = Random.Range(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        enemyLineIndex = Random.Range(0, 9);

        // Basic enemy movement
        /*transform.position += new Vector3(0.5f, 0.5f, 0.0f);

        if (transform.position.y >= 4.0f)
        {
            transform.position = new Vector3(transform.position.x, 4.0f, transform.position.z);
        }

        if (transform.position.x >= 5.0f)
        {
            transform.position = new Vector3(5.0f, transform.position.y, transform.position.z);
        }*/
    }

    private void OnTriggerEnter(Collider collision)
    {
        // If the enemy is being collided by the player, trigger some enemy dialogue
        if (collision.gameObject.name == "Player")
        {
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
            }
        }
    }
}
