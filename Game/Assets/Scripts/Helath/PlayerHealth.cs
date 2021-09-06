using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthBase
{
    public int MaxHealth = 5;

    private int currentHealth;

    protected override void Awake()
    {
        base.Awake();
        currentHealth = MaxHealth;
    }


    protected override void OnReciveDamage(DamagePacket packet, IDamageSource source)
    {
        if (packet.damageAmount > 0)
        {
            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                invokeDeathEvent();
            }
        }
    }
}
