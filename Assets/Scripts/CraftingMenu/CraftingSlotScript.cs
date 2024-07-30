using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlotScript : MonoBehaviour, IDropHandler
{
    public int xCord;
    public int yCord;

    InventoryUI uiScript;
    PlayerStatus status;

    public void OnDrop(PointerEventData eventData)
    {
        int[,] shape = eventData.pointerDrag.GetComponent<ItemScript>().shape;

        // When the crafting slot is clicked, play the clicking sound (whether or not the sound is already playing)
        if (!InventoryUI.inventoryItemSound.isPlaying || InventoryUI.inventoryItemSound.isPlaying)
        {
            InventoryUI.inventoryItemSound.clip = Resources.Load<AudioClip>("SoundEffects/Player/" +
                InventoryUI.inventoryItemClips[0]);

            InventoryUI.inventoryItemSound.Play();
        }

        if (GameObject.Find("Inventory UI").GetComponent<InventoryUI>().Fit(xCord, yCord, shape)){
            //make dragged object child of current slot
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);

            GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>().alchemy[yCord, xCord] = transform.GetChild(0).gameObject;
        }
    }
}
