using System;


[Flags]
public enum DamageFalgs
{
    Undeifined = 0,
    Player = 1 << 0,
    Enemy = 1 << 1,
    Trap = 1<< 2,
    Projectile= 1<<3,


}