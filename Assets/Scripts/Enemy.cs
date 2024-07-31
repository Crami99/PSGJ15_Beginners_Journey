using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private Text subTitleText;

    private float subtitleDisappearTime;

    /*AudioSource enemyAttackSounds;
    List<string> enemyAttackClips;

    private string enemyAttackSoundPath;*/

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

        // Enemy attack sounds initialized but for now, comment them out until the enemy attack animations/logic are done
        /*enemyAttackSounds = GameObject.Find("EnemyAttackSounds").GetComponent<AudioSource>();
        enemyAttackSounds.volume = PlayerPrefs.GetFloat("SFXSliderValue", 100f);

        enemyAttackClips = new List<string> { "enemy attack 1", "enemy attack 2", "enemy attack 3",
        "enemy attack 4", "enemy attack 5"};

        enemyAttackSoundPath = "SoundEffects/Enemy/Attack Sounds/";*/

        //to add new sounds simply place them in the correct folder and add thier name to the list
        spottedClips = new List<string> { "attack final", "burn in thine holy light", "come here final",
        "i see you final", "raaaaah! final", "raah 2 final"};
        
        lostClips = new List<string> { "cant hide for long", "ComeBack final", "where'd it go", 
            "you will die tonight final", "you're not leaving alive"};

        //get patrolPoints
        int pointCount = gameObject.transform.parent.Find("PatrolPoints").childCount;

        patrolPoints = new Transform[pointCount];

        for(int i = 0; i < pointCount; i++){
            patrolPoints[i] = gameObject.transform.parent.Find("PatrolPoints").GetChild(i);
        }

        subTitleText = GameObject.Find("Subtitle Text").GetComponent<Text>();

        subTitleText.text = "";
        subTitleText.fontSize = 20;
        subTitleText.alignment = TextAnchor.MiddleCenter;
        subTitleText.color = Color.white;

        subtitleDisappearTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        subtitleDisappearTime += Time.deltaTime; // Increment the subtitle disappear timer

        EnemyPatrolling();

        // If the subtitle text character length is greater than 0 and the timer reaches past 3 seconds
        if (subTitleText.text.Length > 0)
        {
            if (subtitleDisappearTime > 3.0f)
            {
                subTitleText.text = ""; // Remove the text for now but keep it inside the level

                subtitleDisappearTime = 0.0f; // Reset the timer
            }
        }
    }

    private void EnemyPatrolling()
    {
        if (isEnemyPatrolling == true)
        {
            if (transform.position != patrolPoints[patrolPointIndex].transform.position){
                //move towards patrolPoint
                if (!enemyFootsteps.isPlaying)
                {
                    string path = "SoundEffects/Enemy/Footsteps/";

                    int i = Random.Range(0, footstepClips.Count);

                    enemyFootsteps.clip = Resources.Load<AudioClip>(path + footstepClips[i]);
                    enemyFootsteps.Play();
                }

                //Roatate Enemy to target
                RotateEnemy((Vector2) patrolPoints[patrolPointIndex].transform.position);

                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[patrolPointIndex].transform.position, Time.deltaTime * 2.0f);
            }else{
                patrolPointIndex ++;
                patrolPointIndex = patrolPointIndex % 4;
            }
        }
    }

    private void RotateEnemy(Vector2 target){
        Vector2 dir = (target - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float offset = 90f;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void PlayEnemyCaughtPlayerLines()
    {
        //if the enemy is not currently playing a sound, play a sound
        if (!audioSrc.isPlaying)
        {
            string path = "SoundEffects/Enemy/Spotted/";

            int soundIndex = Random.Range(0, spottedClips.Count);

            if (soundIndex == 0)
            {
                subTitleText.text = "Attack!";

                subtitleDisappearTime = 1.424f;
            }

            else if (soundIndex == 1)
            {
                subTitleText.text = "Burn in thine holy light!";

                subtitleDisappearTime = 0.569f;
            }

            else if (soundIndex == 2)
            {
                subTitleText.text = "Come here!";

                subtitleDisappearTime = 1.651f;
            }

            else if (soundIndex == 3)
            {
                subTitleText.text = "I see you!";

                subtitleDisappearTime = 1.396f;
            }

            else if (soundIndex == 4)
            {
                subTitleText.text = "Raaaaah!!";

                subtitleDisappearTime = 1.424f;
            }

            else if (soundIndex == 5)
            {
                subTitleText.text = "Raah!";

                subtitleDisappearTime = 0.899f;
            }

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

            if (soundIndex == 0)
            {
                subTitleText.text = "Can't hide for long!";

                subtitleDisappearTime = 0.879f;
            }

            else if (soundIndex == 1)
            {
                subTitleText.text = "Hey come back here!";

                subtitleDisappearTime = 1.195f;
            }

            else if (soundIndex == 2)
            {
                subTitleText.text = "Where'd it go?";

                subtitleDisappearTime = 1.828f;
            }

            else if (soundIndex == 3)
            {
                subTitleText.text = "You will die tonight!";

                subtitleDisappearTime = 0.953f;
            }

            else if (soundIndex == 4)
            {
                subTitleText.text = "You're not leaving alive!";

                subtitleDisappearTime = 0.879f;
            }

            audioSrc.clip = Resources.Load<AudioClip>(path + lostClips[soundIndex]);
            audioSrc.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Lightsource" && collision.gameObject.tag == "Player" && 
            collision.gameObject.tag != "Obstacle" || gameObject.tag == "Enemy" && 
            collision.gameObject.tag == "Player" && collision.gameObject.tag != "Obstacle")
        {
            PlayEnemyCaughtPlayerLines();

            isEnemyPatrolling = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.tag == "Lightsource" && collision.gameObject.tag == "Player" && 
            collision.gameObject.tag != "Obstacle" && isEnemyPatrolling == false || 
            gameObject.tag == "Enemy" && collision.gameObject.tag == "Player" &&
            collision.gameObject.tag != "Obstacle" && isEnemyPatrolling == false)
        {
            if (!enemyFootsteps.isPlaying)
            {
                string path = "SoundEffects/Enemy/Footsteps/";

                int i = Random.Range(0, footstepClips.Count);

                enemyFootsteps.clip = Resources.Load<AudioClip>(path + footstepClips[i]);
                enemyFootsteps.Play();
            }
            RotateEnemy((Vector2)player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 10.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == "Lightsource" && collision.gameObject.tag == "Player" && 
            collision.gameObject.tag != "Obstacle" || gameObject.tag == "Enemy" && 
            collision.gameObject.tag == "Player" && collision.gameObject.tag != "Obstacle")
        {
            PlayEnemyLostPlayerLines();
            isEnemyPatrolling = true;
        }
    }
}
