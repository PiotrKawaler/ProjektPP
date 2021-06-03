using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public interface IPlayerAnimatorController
{
    public event Action PlayerJumpedEvent;
    bool IsGrounded();

}
