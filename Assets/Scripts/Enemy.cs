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
        spottedClips = new List<string> {"ComeHere", "ComeToDaddy", "Deathwarrant", "DieTonight", "GetReady", "ISeeYou", "TakeYouDown", "There", "YouThought"};
        lostClips = new List<string> {"Come", "ComeBack", "ComeOut", "DamnIt", "LostHim", "TimeToLook", "Where", "WillFind", "YouThink"};

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
                subTitleText.text = "Come here!";
            }

            else if (soundIndex == 1)
            {
                subTitleText.text = "Come to daddy!";
            }

            else if (soundIndex == 2)
            {
                subTitleText.text = "I'll sign your death warrant at your funeral!";
            }

            else if (soundIndex == 3)
            {
                subTitleText.text = "You will die tonight!";
            }

            else if (soundIndex == 4)
            {
                subTitleText.text = "Get ready to die!";
            }

            else if (soundIndex == 5)
            {
                subTitleText.text = "I see you!";
            }

            else if (soundIndex == 6)
            {
                subTitleText.text = "Time to take you down!";
            }

            else if (soundIndex == 7)
            {
                subTitleText.text = "There he is!";
            }

            else if (soundIndex == 8)
            {
                subTitleText.text = "You thought you were slick? Come here!";
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
                subTitleText.text = "Come to me like a man!";
            }

            else if (soundIndex == 1)
            {
                subTitleText.text = "Hey come back here!";
            }

            else if (soundIndex == 2)
            {
                subTitleText.text = "Come out wherever you are!";
            }

            else if (soundIndex == 3)
            {
                subTitleText.text = "Damn it, where is he?";
            }

            else if (soundIndex == 4)
            {
                subTitleText.text = "Agh, I lost him!";
            }

            else if (soundIndex == 5)
            {
                subTitleText.text = "Time to look for you!";
            }

            else if (soundIndex == 6)
            {
                subTitleText.text = "Where did he go?";
            }

            else if (soundIndex == 7)
            {
                subTitleText.text = "I will find you!";
            }

            else if (soundIndex == 8)
            {
                subTitleText.text = "You think you can stop me?";
            }

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
            RotateEnemy((Vector2)player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 10.0f);
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
