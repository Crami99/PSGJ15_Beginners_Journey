using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    private Text inventoryTitleText;

    // This will be used when the sword is picked up by the player inside the player's inventory
    private RawImage swordInventoryImage1;
    private RawImage swordInventoryImage2;

    // This will be used when the serf is picked up by the player inside the player's inventory
    private RawImage serfInventoryImage1;
    private RawImage serfInventoryImage2;

    // Start is called before the first frame update
    void Start()
    {
        inventoryTitleText = GameObject.Find("Inventory Title Text").GetComponent<Text>();

        swordInventoryImage1 = GameObject.Find("Sword Inventory Image 1").GetComponent<RawImage>();
        swordInventoryImage2 = GameObject.Find("Sword Inventory Image 2").GetComponent<RawImage>();

        serfInventoryImage1 = GameObject.Find("Serf Inventory Image 1").GetComponent<RawImage>();
        serfInventoryImage2 = GameObject.Find("Serf Inventory Image 2").GetComponent<RawImage>();

        swordInventoryImage1.gameObject.SetActive(false);
        swordInventoryImage2.gameObject.SetActive(false);

        serfInventoryImage1.gameObject.SetActive(false);
        serfInventoryImage2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Pauses the game
        Time.timeScale = 0.0f;

        inventoryTitleText.text = "Inventory";
        inventoryTitleText.fontSize = 25;
        inventoryTitleText.alignment = TextAnchor.MiddleCenter;
        inventoryTitleText.color = new Color(1.0f, 0.0f, 0.0f);

        if (Player.sword1PickedUp)
        {
            serfInventoryImage1.gameObject.SetActive(false);
            swordInventoryImage1.gameObject.SetActive(true);
        }

        if (Player.serf1PickedUp && Player.sword2PickedUp)
        {
            serfInventoryImage1.gameObject.SetActive(true);
            swordInventoryImage1.gameObject.SetActive(false);

            swordInventoryImage2.gameObject.SetActive(true);
            serfInventoryImage2.gameObject.SetActive(false);
        }

        if (Player.serf1PickedUp)
        {
            serfInventoryImage1.gameObject.SetActive(true);
            swordInventoryImage1.gameObject.SetActive(false);
        }

        if (Player.sword1PickedUp && Player.serf2PickedUp)
        {
            serfInventoryImage1.gameObject.SetActive(false);
            swordInventoryImage1.gameObject.SetActive(true);

            serfInventoryImage2.gameObject.SetActive(true);
            swordInventoryImage2.gameObject.SetActive(false);
        }
    }

    public void PressBackButton()
    {
        // Hide the inventory HUD and resume game
        gameObject.SetActive(false);
    }
}
