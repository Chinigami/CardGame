using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Target {Player, Enemy, Self};
public abstract class Effect : ScriptableObject
{
    public int value_test;
    public List<int> values = new List<int>();
    public List<Sprite> icons = new List<Sprite>();
    public virtual void Activation(){
        Debug.Log("activation");
    }
}
