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

    CanvasGroup canvasGroup;

    InventoryUI uiScript;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        uiScript = GameObject.Find("Inventory UI").GetComponent<InventoryUI>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(other.gameObject.GetComponent<Player>().playerInventory.Count < 9){
                // add to player Inventory
                other.gameObject.GetComponent<Player>().playerInventory.Add(gameObject);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                //gameObject.GetComponent<RawImage>().enabled = true;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;

        CraftingSlotScript slotScript = transform.parent.GetComponent<CraftingSlotScript>();

        if(transform.parent.tag == "AlchemySlot"){
            uiScript.remove(slotScript.xCord, slotScript.yCord, shape);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position += new Vector3 (eventData.delta.x, eventData.delta.y, 0);
        //transform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.position = transform.parent.GetComponent<Transform>().position;

        //block grid to avoid edgecase
        if(transform.parent.tag == "AlchemySlot"){
            CraftingSlotScript slotScript = transform.parent.GetComponent<CraftingSlotScript>();
            uiScript.fit(slotScript.xCord, slotScript.yCord, shape);
        }
    }
}
