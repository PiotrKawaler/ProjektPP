using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    int MaxHealth = 100;
    int CurrentHealth;
    int Damage = 20; 

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    int GetMaxHealth()
    {
        return MaxHealth;
    }


    int GetDamage()
    {
        return Damage;
    }


    int GetCurrentHealth()
    {
        return CurrentHealth;
    }


    void SetDamage(int damage)
    {
        Damage = damage;
    }


    void SetMaxHealth(int maxHealth)
    {
        MaxHealth = maxHealth;
    }

    
    void SetCurrentHealth(int currentHealth)
    {
        CurrentHealth = currentHealth;
    }
}
