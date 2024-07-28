using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //0 not part of shape, 1 part of shape
    public int[,] shape = {{0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0},
                           {0, 1, 1, 1, 0},
                           {0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0}};

    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    InventoryUI uiScript;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        uiScript = GameObject.Find("Inventory UI").GetComponent<InventoryUI>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;

        CraftingSlotScript slotScript = rectTransform.parent.GetComponent<CraftingSlotScript>();

        if(rectTransform.parent.tag == "AlchemySlot"){
            uiScript.remove(slotScript.xCord, slotScript.yCord, shape);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    
    public void OnDrag(PointerEventData eventData)
    {
        //transform.position += new Vector3 (eventData.delta.x, eventData.delta.y, 0);
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.position = transform.parent.GetComponent<Transform>().position;
    }
}
