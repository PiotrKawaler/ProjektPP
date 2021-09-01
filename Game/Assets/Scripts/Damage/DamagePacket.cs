
using System;

[Flags]
public enum DamageType
{
    None = 0,
    Player =1<<0,
    Trap = 1<<1,
    Enemy = 1<<2,

}


[Serializable]
public struct DamagePacket
{

    public float damageAmount;
    public DamageType damageType;

}