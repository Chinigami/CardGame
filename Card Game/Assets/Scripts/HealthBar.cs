using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject shield;
    public Text shieldText;
    private int shieldValue = 0;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public int GetShield(){
        return shieldValue;
    }

    public void AddShield(int value){
        if(shieldValue <= 0 && value > 0){
            shield.SetActive(true);
        }
        shieldValue += value;
        SetShieldValue();
        if(shieldValue <= 0){
            BreakShield();
        }
    }

    private void SetShieldValue(){
        shieldText.text = shieldValue.ToString();
    }

    public void BreakShield(){
        shieldValue = 0;
        SetShieldValue();
        shield.SetActive(false);
    }
}
