using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //only read from these after loading scene, only write to these before unloading scene
    public float playerHealth;
    public float playerShield;

    //add inventory here

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainMenu");

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
        playerHealth = 100f;
        playerShield = 100f;
    }
}
