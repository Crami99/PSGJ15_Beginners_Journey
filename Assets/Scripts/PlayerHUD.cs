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
        // Resumes the game
        Time.timeScale = 1.0f;
    }

    public void PressInventoryButton()
    {
        // Open up the inventory HUD for the player
        Player.inventoryHUD.SetActive(true);
    }

    public void PressPauseButton()
    {
        // Open the pause menu for the player
        Player.pauseMenu.SetActive(true);
    }
}
