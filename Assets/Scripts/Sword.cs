using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Transform swordHit;
    PlayerStatus status;

    // Start is called before the first frame update
    void Start()
    {
        swordHit = GameObject.Find("SwordHit").GetComponent<Transform>();
        status = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && transform.position.x <= swordHit.transform.position.x &&
                transform.position.y <= swordHit.transform.position.y && transform != null)
        {
            if (status.shield + status.shieldMod> 0)
            {
                status.shield = status.shield - 5.0f * Time.deltaTime;
            }
            else
            {
                status.health = status.health - 5.0f * Time.deltaTime;
            }
        }
    }
}
