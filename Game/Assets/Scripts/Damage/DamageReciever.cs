using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciever : MonoBehaviour
{
    public virtual void ReciveDamage(DamagePacket damagePacket)
    {
        Debug.Log($"Using Base Class {nameof(DamageReciever)} (overide me)");
    }

    public virtual bool IsValidTarget(DamagePacket damagePacket)
    {
        Debug.Log($"Using Base Class {nameof(DamageReciever)} (overide me)");
        return false;
    }

}
