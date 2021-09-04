using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public abstract class DamageRecieverBase : MonoBehaviour
{

    public Action<DamagePacket, IDamageSource> RecivedDamageEvent;


    public virtual void ReciveDamage(DamagePacket damagePacket, IDamageSource damageSource)
    {
        if (IsValidTarget(damagePacket, damageSource))
        {
            RecivedDamageEvent?.Invoke(damagePacket, damageSource);
        }
    }

    public abstract bool IsValidTarget(DamagePacket damagePacket, IDamageSource damageSource);


}
