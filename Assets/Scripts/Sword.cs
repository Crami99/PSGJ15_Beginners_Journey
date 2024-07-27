using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Transform swordHit;

    // Start is called before the first frame update
    void Start()
    {
        swordHit = GameObject.Find("SwordHit").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && transform.position.x <= swordHit.transform.position.x &&
                transform.position.y <= swordHit.transform.position.y)
        {
            if (Player.playerShield > 0)
            {
                Player.playerShield = Player.playerShield - 5.0f * Time.deltaTime;
            }
            else
            {
                Player.playerHealth = Player.playerHealth - 5.0f * Time.deltaTime;
            }
        }
    }
}
