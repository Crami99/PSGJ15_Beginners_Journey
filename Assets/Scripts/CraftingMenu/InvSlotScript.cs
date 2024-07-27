using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvSlotScript : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && transform.childCount == 0){
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
        }
    }
}
