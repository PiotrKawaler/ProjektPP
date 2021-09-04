using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHealth : HealthBase
{
    [SerializeField] private float MaxHealth = 10;

    private float currentHealth;

    protected override void Awake()
    {
        base.Awake();
    }


    protected override void OnReciveDamage(DamagePacket packet, IDamageSource source)
    {
        if (packet.damageAmount > 0)
        {
            currentHealth -= packet.damageAmount;

            if (currentHealth <= 0)
            {
                invokeDeathEvent();
            }
        }
    }
}
