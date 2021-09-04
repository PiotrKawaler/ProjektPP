using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class HealthBase : MonoBehaviour, IDeathEventCaller
{

    public event Action DeathEvent;


    protected DamageRecieverBase damageReciever;

    protected void invokeDeathEvent()
    {
        DeathEvent?.Invoke();
    }

    protected virtual void Awake()
    {
        damageReciever = GetComponent<DamageRecieverBase>();


        if(damageReciever)
            damageReciever.RecivedDamageEvent += OnReciveDamage;
    }
    protected virtual void OnDestroy()
    {
        if(damageReciever)
            damageReciever.RecivedDamageEvent -= OnReciveDamage;
    }

    protected abstract void OnReciveDamage(DamagePacket packet,IDamageSource source);


}
