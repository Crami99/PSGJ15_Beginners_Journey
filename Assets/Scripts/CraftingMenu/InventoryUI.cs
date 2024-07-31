using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //0 = slot open, 1 = slot full, 2 = slot locked
    int[,] craftingGridStatus = {{2, 0, 0, 0, 2},
                                 {0, 0, 0, 0, 0},
                                 {0, 0, 0, 0, 0},
                                 {0, 0, 0, 0, 0},
                                 {2, 0, 0, 0, 2}};

    GameObject[,] craftingSlot = new GameObject[5,5];

    Transform craftingBackground;
    Transform alchemySlots;
    Transform inventorySlots;

    bool dragging;

    GameObject player;

    PlayerStatus status;

    public static AudioSource inventoryItemSound;
    public static List<string> inventoryItemClips;

    // Start is called before the first frame update
    void Start()
    {
        alchemySlots = transform.Find("Canvas/Crafting/Slots").transform;
        inventorySlots = transform.Find("Canvas/InventorySlots").transform;

        inventoryItemSound = GameObject.Find("InventoryItemSounds").GetComponent<AudioSource>();
        inventoryItemSound.volume = PlayerPrefs.GetFloat("SFXSliderValue", 100f);

        // Get the different clips of inventory item sounds inside the path folder
        inventoryItemClips = new List<string> { "player inventory item click", "player inventory item placed" };

        player = GameObject.Find("Player");
        status = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        
        //initialize inventory
        for(int i = 0; i < 9; i++){
            inventorySlots.GetChild(i).GetComponent<InvSlotScript>().index = i;
        }

        //initialize Crafting Grid
        for(int y = 0; y < 5; y++){
            for(int x = 0; x < 5; x++){
                craftingSlot[y,x] = alchemySlots.GetChild(y * 5 + x).gameObject;

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
    }

    // Update is called once per frame
    void Update()
    {
        // Pauses the game
        Time.timeScale = 0.0f;

        //if I is pressed leave Inventory
        if(Input.GetKeyDown(KeyCode.I)){
            CloseInv();
        }

        //update from playerInventory
        if(Input.GetKeyUp(KeyCode.I)){
            UpdateInv();
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

    //tries to fit the passed shape into the carfting grid; on success true is returned and tcraftingGridStaus is ajusted
    //shape has to be 5x5 array
    public bool Fit(int xCord, int yCord, int[,] shape)
    {
        //Check if shape fits
        for(int y = 0; y < 5; y++){
            for(int x = 0; x < 5; x++){
                if(shape[y,x] == 1){
                    //if part of shape outside of array return false
                    if(y + yCord - 2 < 0 || y + yCord - 2 > 4 || x + xCord - 2 < 0 || x + xCord - 2 > 4){
                        return false;
                    }
                    if(craftingGridStatus[y + yCord - 2, x + xCord - 2] != 0){
                        return false;
                    }
                }
            }
        }
        //mark shape
        for(int y = 0; y < 5; y++){
            for(int x = 0; x < 5; x++){
                if(shape[y,x] == 1){
                    craftingGridStatus[y + yCord - 2, x + xCord - 2] = 1;
                }
            }
        }
        return true;
    }

    public void remove (int xCord, int yCord, int[,] shape)
    {
        for(int y = 0; y < 5; y++){
            for(int x = 0; x < 5; x++){
                if(shape[y,x] == 1){
                    craftingGridStatus[y + yCord - 2, x + xCord - 2] = 0;
                }
            }
        }
    }

    //makes sure all items are displayed at the correct position in Ui
    public void UpdateInv()
    {   
        //Debug.Log(inventorySlots);
        //get Inventory from status.inventory
        for(int i = 0; i < status.inventory.Count; i++){
            GameObject item = status.inventory[i];

            item.transform.SetParent(inventorySlots.GetChild(i));
            item.transform.position = item.transform.parent.position;

            item.transform.localScale = new Vector3(130, 130, 0);
        }

        //Debug.Log(alchemySlots);
        for(int y = 0; y < 5; y++){
            for(int x = 0; x < 5; x++){
                if(status.alchemy[y,x] != null){
                    
                    status.alchemy[y,x].transform.SetParent(alchemySlots.GetChild(y * 5 + x));
                    status.alchemy[y,x].transform.position = status.alchemy[y,x].transform.parent.position;
                    Fit(x, y, status.alchemy[y,x].GetComponent<ItemScript>().shape);

                }
            }
        }

    }

    //makes sure all Items in inventory get DontDestroyOnLoad and updates player values
    public void CloseInv()
    {
        // Hide the inventory HUD and resume game
        gameObject.SetActive(false);

        PlayerStatus.buttonPressSound.Play();

        //move childs back to status
        for (int i = 0; i < inventorySlots.childCount; i++){
            if(inventorySlots.GetChild(i).childCount > 0){
                GameObject item = inventorySlots.GetChild(i).GetChild(0).gameObject;

                item.transform.SetParent(null);
                DontDestroyOnLoad(item);
            }
        }

        float curShieldMod = 0;
        float curHealthMod = 0;
        float curSpeedMod = 1;

        for(int y = 0; y < 5; y++){
            for(int x = 0; x < 5; x++){
                if(status.alchemy[y,x] != null){
                    GameObject item = status.alchemy[y,x];
                    item.transform.SetParent(null);
                    DontDestroyOnLoad(item);

                    curShieldMod += item.GetComponent<ItemScript>().shieldMod;
                    curHealthMod += item.GetComponent<ItemScript>().healthMod;
                    curSpeedMod += item.GetComponent<ItemScript>().speedMod;
                }
            }
        }
        status.shieldMod = curShieldMod;
        status.healthMod = curHealthMod;
        status.speedMod = curSpeedMod;

        //Debug.Log("Shield Mod: " + status.shieldMod + " Health Mod:" + status.healthMod + " Speed Mod: " + status.speedMod);
    }
}
