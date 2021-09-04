using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRecieverAnyFlag : DamageRecieverBase
{


    [SerializeField] private DamageFalgs reciveDamageFlags;
    public override bool IsValidTarget(DamagePacket damagePacket, IDamageSource damageSource)
    {
        int logicAndResult = (int)reciveDamageFlags & (int)damagePacket.damageType;

        return logicAndResult != 0;
    }


}
