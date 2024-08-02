using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int currentHealth = 10;
    [SerializeField] HealthBar healthBar;
    private Flash damageFlash;

    public void Awake(){
        if(healthBar != null){
            healthBar.SetMaxHealth(maxHealth);
        }

        damageFlash = GetComponent<Flash>();
    }

    public void TakeDamage(int damage){
        if(damage < 0){
            damage = 0;
        }

        currentHealth -= damage;
        damageFlash.CallFlashRoutine();

        if(healthBar != null){
            healthBar.SetHealth(currentHealth);
        }
        
        if (currentHealth < 0){
            currentHealth = 0;
        }
    }


    public void Heal(int heal){
        if(heal < 0){
            heal = 0;
        }

        currentHealth += heal;
        if (currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }

    //--------------------

    public int GetCurrentHealth(){
        return currentHealth;
    }

    public void SetCurrentHealth(int newHealth){
        currentHealth = newHealth;
    }

    public int GetMaxHealth(){
        return maxHealth;
    }

    public void SetMaxHealth(int newMax){
        maxHealth = newMax;
        healthBar.SetMaxHealth(newMax);
    }
}
