using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    //only read from these after loading scene, only write to these before unloading scene
    public float health;
    public float healthMod;

    public float shieldBase = 100f;
    public float shield;
    public float shieldMod;

    public float speed;
    public float speedMod;

    public List<GameObject> inventory;
    public GameObject[,] alchemy;

    public List<string> roomList;

    public static AudioSource menuMusic;
    public static AudioSource buttonPressSound;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Status");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        menuMusic = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        menuMusic.volume = PlayerPrefs.GetFloat("MusicSliderValue", 100f);

        menuMusic.loop = true;
        menuMusic.Play();

        DontDestroyOnLoad(menuMusic);

        buttonPressSound = GameObject.Find("ButtonPressSound").GetComponent<AudioSource>();
        buttonPressSound.volume = PlayerPrefs.GetFloat("SFXSliderValue", 100f);

        buttonPressSound.clip = Resources.Load<AudioClip>("SoundEffects/main menu button press");

        DontDestroyOnLoad(buttonPressSound);
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetStats();
    }

    private void Update()
    {
        if (menuMusic.isPlaying == false)
        {
            menuMusic.Play();
            menuMusic.volume = PlayerPrefs.GetFloat("MusicSliderValue", 100f);
        }
    }

    public void ResetStats(){
        health = 100f;
        healthMod = 0f;
        
        shield = shieldBase;
        shieldMod = 0f;
        

        speed =  200f;
        speedMod = 1;

        inventory = new List<GameObject>();
        alchemy = new GameObject[5,5];
    }

    public void CreateRoomList()
    {
        //add all rooms to room list
        roomList = new List<string>();
        roomList.Add("Room 0");
        //roomList.Add("Room 2");
        //roomList.Add("Room 1");
        
    }

    public void NextRoom(){
        if(roomList.Count > 0){
            //if there are rooms, go to rendom romm
            //int roomIndex = Random.Range(0, roomList.Count);
            int roomIndex = 0;
            string nextRoom = roomList[roomIndex];
            roomList.RemoveAt(roomIndex);
            SceneManager.LoadScene(nextRoom);
        }else{
            SceneManager.LoadScene("GameWon");
        }
    }

    public void Restart(){
        ResetStats();
        CreateRoomList();

        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");

        foreach(GameObject item in items){
            Destroy(item);
        }
    }
}
