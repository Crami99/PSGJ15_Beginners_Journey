using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Pauses the game
        Time.timeScale = 1.0f;
    }

    public void PressInventoryButton()
    {
        // Open up the inventory HUD for the player
        Player.inventoryHUD.SetActive(true);
    }
}
