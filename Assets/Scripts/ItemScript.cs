using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemScript : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    //0 not part of shape, 1 part of shape
    public int[,] shape = {{0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0},
                           {0, 1, 1, 1, 0},
                           {0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0}};

    CanvasGroup canvasGroup;

    InventoryUI uiScript;
    Player playerScript;
    PlayerStatus status;

    void Awake()
    {   
        //get relevant components
        canvasGroup = GetComponent<CanvasGroup>();
        uiScript = GameObject.Find("Inventory UI").GetComponent<InventoryUI>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        status = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(status.inventory.Count < 9){
                // add to player Inventory
                DontDestroyOnLoad(gameObject);
                status.inventory.Add(gameObject);
                HideItem();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;

        if(transform.parent.tag == "AlchemySlot"){
            //remove from Crafting
            CraftingSlotScript slotScript = transform.parent.GetComponent<CraftingSlotScript>();
            uiScript.remove(slotScript.xCord, slotScript.yCord, shape);

            status.alchemy[slotScript.yCord, slotScript.xCord] = null;
        }

        if(transform.parent.tag == "InventorySlot"){
            //remove Item from Inventroy
            InvSlotScript slotScript = transform.parent.GetComponent<InvSlotScript>();
            status.inventory.RemoveAt(slotScript.index);
        }
    }
    
    public void HideItem()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
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
            uiScript.Fit(slotScript.xCord, slotScript.yCord, shape);
        }

        if(transform.parent.tag == "InventorySlot"){
            status.inventory.Add(transform.gameObject);
        }
        uiScript.UpdateInv();
    }
}
