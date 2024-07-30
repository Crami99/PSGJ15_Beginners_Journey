using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroScript : MonoBehaviour
{
    // Reference to the intro video object
    private VideoPlayer introVideo;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // Find the intro video object first
        introVideo = GameObject.Find("Intro").GetComponent<VideoPlayer>();

        timer = 0.0f;

        // Find the intro video URL at the StreamingAssets path
        introVideo.url = System.IO.Path.Combine(Application.streamingAssetsPath, "The Beginner's Journey Intro.mp4");

        // Play the intro video at the start as soon as the object is found
        introVideo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // If the timer is greater than or equal to 8, transition to the main menu
        if (timer >= 8.0f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
