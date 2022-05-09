using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTop : MonoBehaviour
{
    public void cardActivation(){

        // child = dernier élément ajouté à tabletop, donc dernière carte joué
        Transform child = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1);
        Card c = child.GetComponent<Card>();

        // On enlève le mana dépensé
        BattleManager.instance.AddMana(-c.cardCost);

        // On ne peut plus drag une carte une fois joué
        Draggable d = child.GetComponent<Draggable>();
        if(d != null) {
            Destroy(d);
        }

        // On exécute tous les effets un par un
        if(c != null) {
            List<Effect> effects = c.data.effects;
            foreach (var e in effects)
            {
                e.Activation();
            }
        }
        // Puis on exécute la carte (lol)
        BattleManager.instance.DiscardCard(c);
    }
}
