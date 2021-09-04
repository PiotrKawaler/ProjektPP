using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundDamageReciever : DamageRecieverBase
{

    //Ground captures projectiles

    public override bool IsValidTarget(DamagePacket damagePacket, IDamageSource damageSource)
    {
        DamageFalgs flags = damagePacket.damageType;

        bool result = flags.HasFlag(DamageFalgs.Projectile);
        return result;
    }

    public override void ReciveDamage(DamagePacket damagePacket, IDamageSource damageSource)
    {
        return;
    }


}
