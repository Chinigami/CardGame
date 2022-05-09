using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Unit
{
    public List<Effect> actions;
    public Transform IconsOrigin;
    public Sprite noSprite;
    public Image[] icons;
    public Text[] iconsValues;
    public override void Die(){
        Debug.Log("You Win !");
    }

    public void SetIcon(List<Sprite> list_s, List<int> list_i){
        for(int i_ = 0; i_ < icons.Length; i_++){
            icons[i_].sprite = noSprite;
            iconsValues[i_].text = "";
        }
        for(int i = 0; i < list_s.Count; i++){
            icons[i].sprite = list_s[i];
            if(list_i[i] > 0){
                iconsValues[i].text = list_i[i].ToString();
            } else {
                iconsValues[i].text = "";
            }
        }
    }
}
