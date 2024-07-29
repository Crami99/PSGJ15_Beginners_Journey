using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    //only read from these after loading scene, only write to these before unloading scene
    public float health;
    public float shield;

    public float speed;

    public List<GameObject> inventory;
    public GameObject[,] alchemy;

    public List<string> roomList = new List<string>();

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Status");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetStats();
    }

    public void ResetStats(){
        health = 100f;
        shield = 100f;

        speed =  200f;

        inventory = new List<GameObject>();
        alchemy = new GameObject[5,5];
    }

    public void CreateRoomList()
    {
        //add all rooms to room list
        roomList.Add("Room 1");
        //roomList.Add("Room 2");
        roomList.Add("Room 1");
        
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
