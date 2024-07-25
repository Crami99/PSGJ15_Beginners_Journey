using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Resumes the game
        Time.timeScale = 0.0f;
    }

    public void PressBackButton()
    {
        // Hide the inventory HUD and resume game
        gameObject.SetActive(false);
    }
}
