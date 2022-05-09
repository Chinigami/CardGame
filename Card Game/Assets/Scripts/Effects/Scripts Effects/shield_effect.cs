using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "My Game/Card Effect/shield_effect")]
public class shield_effect : Effect
{
    public Target target;
    public override void Activation()
    {
        foreach(int value in values){
            if(target == Target.Enemy){
                BattleManager.instance.enemy.healthBar.AddShield(value);
            } else if(target == Target.Player){
                BattleManager.instance.player.healthBar.AddShield(value);
            }
        }
    }
}
