using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroScript : MonoBehaviour
{
    // Reference to the intro video object
    private VideoPlayer introVideo;

    // Start is called before the first frame update
    void Start()
    {
        // Find the intro video object first
        introVideo = GameObject.Find("Intro").GetComponent<VideoPlayer>();

        // Play the intro video at the start as soon as the object is found
        introVideo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // IF the intro video is not playing, transition to the main menu
        if (!introVideo.isPlaying)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
