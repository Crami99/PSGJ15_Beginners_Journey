using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    
    //0 = health, 1 = shield, 2 = speed 
    public int type = 0;

    public int[,] shape;

    public float shieldMod;
    public float healthMod;
    public float speedMod;

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

        SceneManager.activeSceneChanged += ChangedActiveScene;

        switch(type){
            case 0:
                //health
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
                gameObject.GetComponent<RawImage>().color = new Color(255, 0, 0, 255);

                shieldMod = 0f;
                healthMod = 50f;
                speedMod = 0f;

                //0 not part of shape, 1 part of shape
                shape = new int[5,5]{{0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0},
                                     {0, 1, 1, 1, 0},
                                     {0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0}};
            break;

            case 1:
                //shield
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 255);
                gameObject.GetComponent<RawImage>().color = new Color(0, 0, 255, 255);

                shieldMod = 25f;
                healthMod = 0f;
                speedMod = 0f;
                
                //0 not part of shape, 1 part of shape
                shape = new int[5,5]{{0, 0, 0, 0, 0},
                                     {0, 0, 1, 0, 0},
                                     {0, 0, 1, 1, 0},
                                     {0, 0, 1, 0, 0},
                                     {0, 0, 0, 0, 0}};
            break;

            case 2:
                //speed
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 255);
                gameObject.GetComponent<RawImage>().color = new Color(0, 255, 0, 255);

                shieldMod = 0f;
                healthMod = 0f;
                speedMod = 0.5f;

                //0 not part of shape, 1 part of shape
                shape = new int[5,5]{{0, 0, 0, 0, 0},
                                     {0, 0, 1, 0, 0},
                                     {0, 0, 1, 0, 0},
                                     {0, 0, 1, 0, 0},
                                     {0, 0, 0, 0, 0}};
            break;
        }
    }

    //find new scripts after scene change
    private void ChangedActiveScene(Scene current, Scene next)
    {
        if(GameObject.Find("Inventory UI") != null){
            uiScript = GameObject.Find("Inventory UI").GetComponent<InventoryUI>();
            playerScript = GameObject.Find("Player").GetComponent<Player>();
            status = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        }
        
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
