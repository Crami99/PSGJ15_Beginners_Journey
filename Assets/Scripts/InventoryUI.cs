using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Text inventoryTitleText;

    //0 = slot open, 1 = slot full, 2 = slot locked
    int[,] craftingGridStatus = {{2, 2, 0, 2, 2},
                                 {2, 1, 0, 0, 2},
                                 {0, 0, 1, 0, 0},
                                 {2, 0, 0, 1, 2},
                                 {2, 2, 0, 2, 2}};

    GameObject[,] craftingSlot = new GameObject[5,5];

    Transform craftingBackground;
    Transform slots;

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
        
        Transform slots = transform.Find("Canvas/Crafting/Slots").transform;
        
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                craftingSlot[i,j] = slots.GetChild(i * 5 + j).gameObject;
                switch(craftingGridStatus[i,j]){
                    case 0:
                        craftingSlot[i,j].GetComponent<RawImage>().color = new Color32(90, 115, 120, 20);
                        break;

                    case 1:
                        craftingSlot[i,j].GetComponent<RawImage>().color = new Color32(255, 0, 0, 20);
                        break;

                    case 2:
                        craftingSlot[i,j].GetComponent<RawImage>().color = new Color32(0, 0, 0, 0);
                        break;
                }
            }
        }

        craftingBackground = transform.Find("Canvas/Crafting/Background");

        swordInventoryImage1 = GameObject.Find("Sword Inventory Image 1").GetComponent<RawImage>();
        swordInventoryImage2 = GameObject.Find("Sword Inventory Image 2").GetComponent<RawImage>();

        serfInventoryImage1 = GameObject.Find("Serf Inventory Image 1").GetComponent<RawImage>();
        serfInventoryImage2 = GameObject.Find("Serf Inventory Image 2").GetComponent<RawImage>();

        swordInventoryImage1.gameObject.SetActive(false);
        swordInventoryImage2.gameObject.SetActive(false);

        serfInventoryImage1.gameObject.SetActive(false);
        serfInventoryImage2.gameObject.SetActive(false);
        
        inventoryTitleText.text = "Inventory";
        inventoryTitleText.fontSize = 25;
        inventoryTitleText.alignment = TextAnchor.MiddleCenter;
        inventoryTitleText.color = new Color(1.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Pauses the game
        Time.timeScale = 0.0f;

        //if I is pressed leave Inventory
        if(Input.GetKeyDown(KeyCode.I)){
            PressBackButton();
        }

        //framerate dependend, but since time is stoped I cant think of anything else
        craftingBackground.Rotate(new Vector3(0, 0, -0.1f));



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
