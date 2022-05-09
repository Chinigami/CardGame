using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject newParent;    // Où va aller la carte
    public void OnPointerEnter(PointerEventData eventData){
        
    }

    public void OnPointerExit(PointerEventData eventData){
        
    }
    
    public void OnDrop(PointerEventData eventData){
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d == null){
            return;
        }
        Card c = eventData.pointerDrag.GetComponent<Card>();
        if(c == null){
            return;
        }
        if(c.cardCost > BattleManager.instance.mana){
            BattleManager.instance.CantPlayCardAnim();
            return;
        }
        d.parentToReturnTo = newParent.transform;
    }
}
