using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public int mana = 3;
    public override void Die(){
        Debug.Log("You Died !");
    }
}
