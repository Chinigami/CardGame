using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "My Game/Card Effect/heal_effect")]
public class heal_effect : Effect
{
    public Target target;
    public override void Activation()
    {
        foreach(int value in values){
            if(target == Target.Enemy){
                BattleManager.instance.enemy.Heal(value);
            } else if(target == Target.Player){
                BattleManager.instance.player.Heal(value);
            }
        }
    }
}
