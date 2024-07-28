using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlotScript : MonoBehaviour, IDropHandler
{
    public int xCord;
    public int yCord;

    InventoryUI uiScript;
    
    void Awake()
    {
        uiScript = GameObject.Find("Inventory UI").GetComponent<InventoryUI>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        int[,] shape = eventData.pointerDrag.GetComponent<ItemScript>().shape;

        if(uiScript.fit(xCord, yCord, shape)){
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
        }
    }
}
