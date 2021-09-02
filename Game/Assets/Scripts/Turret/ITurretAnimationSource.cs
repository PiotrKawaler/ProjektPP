using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface  ITurretAnimationSource 
{
    event Action shootEvent;
    void shootAnimCallback();
}
