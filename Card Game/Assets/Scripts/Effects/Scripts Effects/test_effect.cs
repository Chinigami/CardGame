using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "My Game/Card Effect/test_effect")]
public class test_effect : Effect
{
    public override void Activation()
    {
        string retour = "test ";
        foreach(int i in values){
            retour += i.ToString() + " ";
        }
        Debug.Log(retour);
    }
}
