using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "My Game/Card Effect/draw_effect")]
public class draw_effect : Effect
{
    public override void Activation()
    {
        foreach(int value in values){
            for(int i = 0; i < value; i++){
                BattleManager.instance.DrawCard();
            }
        }
    }
}
