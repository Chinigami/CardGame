using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "My Game/Card Data")]
public class CardData : ScriptableObject
{
    public int cost = 1;
    public string name;
    public Sprite img;
    public string effect;
    public Color color;
    public List<Effect> effects;
}
