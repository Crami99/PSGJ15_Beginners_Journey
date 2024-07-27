using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlotScript : MonoBehaviour, IDropHandler
{
    public int xCord;
    public int yCord;
    
    public void OnDrop(PointerEventData eventData)
    {
        //xCord, yCord, eventData.pointerDrag.GetComponent<ItemScript>().shape
        int[,] shape = eventData.pointerDrag.GetComponent<ItemScript>().shape;
        Debug.Log(shape.ToString());

        if(eventData.pointerDrag != null && GameObject.Find("Inventory UI").GetComponent<InventoryUI>().fit(xCord, yCord, shape)){
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
        }
    }
}
