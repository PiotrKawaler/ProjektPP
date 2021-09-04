using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageSource 
{
    Vector2 GetDamagePosition();
    GameObject GetGameObject();
}
