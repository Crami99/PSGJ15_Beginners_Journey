using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Text inventoryTitleText;

    //0 = slot open, 1 = slot full, 2 = slot locked
    int[,] craftingGridStatus = {{2, 2, 0, 2, 2},
                                 {2, 0, 0, 0, 2},
                                 {0, 0, 0, 0, 0},
                                 {2, 0, 0, 0, 2},
                                 {2, 2, 0, 2, 2}};

    GameObject[,] craftingSlot = new GameObject[5,5];

    Transform craftingBackground;
    Transform slots;

    // Start is called before the first frame update
    void Start()
    {
        inventoryTitleText = GameObject.Find("Inventory Title Text").GetComponent<Text>();
        
        Transform slots = transform.Find("Canvas/Crafting/Slots").transform;
        
        for(int y = 0; y < 5; y++){
            for(int x = 0; x < 5; x++){
                craftingSlot[y,x] = slots.GetChild(y * 5 + x).gameObject;

                //tell the child its coordinates
                craftingSlot[y,x].GetComponent<CraftingSlotScript>().xCord = x;
                craftingSlot[y,x].GetComponent<CraftingSlotScript>().yCord = y;

                switch(craftingGridStatus[y,x]){
                    case 0:
                        craftingSlot[y,x].GetComponent<RawImage>().color = new Color32(90, 115, 120, 20);
                        break;

                    case 1:
                        craftingSlot[y,x].GetComponent<RawImage>().color = new Color32(255, 0, 0, 20);
                        break;

                    case 2:
                        craftingSlot[y,x].GetComponent<RawImage>().color = new Color32(0, 0, 0, 0);
                        break;
                }
            }
        }

        craftingBackground = transform.Find("Canvas/Crafting/Background");

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

        for(int y = 0; y < 5; y++){
            for(int x = 0; x < 5; x++){
                switch(craftingGridStatus[y,x]){
                    case 0:
                        craftingSlot[y,x].GetComponent<RawImage>().color = new Color32(90, 115, 120, 20);
                        break;

                    case 1:
                        craftingSlot[y,x].GetComponent<RawImage>().color = new Color32(255, 0, 0, 20);
                        break;

                    case 2:
                        craftingSlot[y,x].GetComponent<RawImage>().color = new Color32(0, 0, 0, 0);
                        break;
                }
            }
        }

        //framerate dependend, but since time is stoped I cant think of anything else
        craftingBackground.Rotate(new Vector3(0, 0, -0.1f));
    }

    //tries to fir the passed shape into the carfting grid; on success true is returned and tcraftingGridStaus is ajusted
    //shape has to be 5x5 array
    public bool fit(int xCord, int yCord, int[,] shape)
    {
        for(int y = 0; y < 5; y++){
            for(int x = 0; x < 5; x++){
                if(shape[x,y] == 1){
                    if(craftingGridStatus[x,y] != 0){
                        return false;
                    }else{
                        craftingGridStatus[x,y] = 1;
                    }
                }
            }
        }
        return true;
    }

    public void PressBackButton()
    {
        // Hide the inventory HUD and resume game
        gameObject.SetActive(false);
    }
}
