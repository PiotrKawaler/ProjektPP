using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthBase
{
    [SerializeField]private int maxHealth = 5;
    public int MaxHealth { get => maxHealth; }

    public void SetMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        MaxHealthChangedEvent?.Invoke(maxHealth);

    }





    private int currentHealth;
    public int CurrentHealth { get => currentHealth; }

    public event Action<int> HealthChangedEvent;
    public event Action<int> MaxHealthChangedEvent;

    protected override void Awake()
    {
        base.Awake();
        currentHealth = maxHealth;
    }


    protected override void OnReciveDamage(DamagePacket packet, IDamageSource source)
    {
        if (packet.damageAmount > 0)
        {
            currentHealth -= 1;

            HealthChangedEvent?.Invoke(currentHealth);

            if (currentHealth <= 0)
            {
                invokeDeathEvent();
            }
        }
    }

    public void RestoreToFull()
    {
        currentHealth = maxHealth;
        HealthChangedEvent?.Invoke(currentHealth);
    }
}
