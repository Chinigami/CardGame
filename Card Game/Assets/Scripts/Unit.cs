using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string name;
    public HealthBar healthBar;
    public int baseHealth = 10;
    public int currentHealth;
    void Start()
    {
        currentHealth = baseHealth;
    }

    public void TakeDamage(int damage){
        if(healthBar.GetShield() >= damage){
            healthBar.AddShield(-damage);
        } else {
            damage -= healthBar.GetShield();
            healthBar.BreakShield();
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if(currentHealth < 0){
                Die();
            }
        }
    }

    public void Heal(int amount){
        if(currentHealth+amount > baseHealth){
            currentHealth = baseHealth;
        } else {
            currentHealth += amount;
        }
        healthBar.SetHealth(currentHealth);
    }

    public virtual void Die(){
        Debug.Log(name + " Died !");
    }
}
