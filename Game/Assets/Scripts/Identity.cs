using System;


[Flags]
public enum Identity
{
    Undeifined = 0,
    Player = 1<<0,
    Enemy = 1<<1,
}


