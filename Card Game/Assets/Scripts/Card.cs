using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int id = -1;
    public int cardCost;
    public Text costText;
    public Text cardName;
    public Image cardImg;
    public Text cardEffect;
    public CardData data;
    
    void Awake()
    {
        cardCost = data.cost;
        costText.text = data.cost.ToString();
        cardName.text = data.name;
        cardImg.sprite = data.img;
        cardEffect.text = data.effect;
        this.transform.GetComponent<Image>().color = data.color;
    }
}
