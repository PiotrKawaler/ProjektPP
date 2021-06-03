using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerAnimatorController
{
    public event Action PlayerJumpedEvent;

    public bool IsGrounded()
    {
        return grounded;
    }

    bool grounded = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJumpedEvent?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            grounded = !grounded;
        }


    }


}
