using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvSlotScript : MonoBehaviour, IDropHandler
{
    public int index;
    public void OnDrop(PointerEventData eventData)
    {
        // When the crafting slot is clicked, play the placed sound (whether or not the sound is already playing)
        if (!InventoryUI.inventoryItemSound.isPlaying || InventoryUI.inventoryItemSound.isPlaying)
        {
            InventoryUI.inventoryItemSound.clip = Resources.Load<AudioClip>("SoundEffects/Player/" +
                InventoryUI.inventoryItemClips[1]);

            InventoryUI.inventoryItemSound.Play();
        }

        if (eventData.pointerDrag != null && transform.childCount == 0){
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
        }
    }
}
