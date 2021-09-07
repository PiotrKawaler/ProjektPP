using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciever : DamageRecieverBase
{
    [Header("Settings")]
    [SerializeField] DamageFalgs anyFlags;
    [SerializeField] float invicibilityDuration = 1;
    

    private float lastDamageTimestamp = 0;


    public override bool IsValidTarget(DamagePacket damagePacket, IDamageSource damageSource)
    {
        int logicAndResult = (int)anyFlags & (int)damagePacket.damageType;

        return logicAndResult != 0&& Time.time- lastDamageTimestamp>= invicibilityDuration;
    }

    public override void ReciveDamage(DamagePacket damagePacket, IDamageSource damageSource)
    {
        if (IsValidTarget(damagePacket, damageSource))
        {

            lastDamageTimestamp = Time.time;
            RecivedDamageEvent?.Invoke(damagePacket, damageSource);
        }
    }


}
