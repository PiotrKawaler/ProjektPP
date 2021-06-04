using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(OrbGun))]
public class PlayerController : MonoBehaviour
{

    PlayerMover playerMover;
    OrbGun orbGun;


    private void Awake()
    {
        playerMover = GetComponent<PlayerMover>();
        orbGun = GetComponent<OrbGun>();
    }




    private void Update()
    {
        bool jumpPressed = Input.GetKey(KeyCode.Space)| Input.GetKey(KeyCode.Z);
        float horizontal = Input.GetAxisRaw("Horizontal");

        playerMover.ReadInputs(horizontal, jumpPressed);

        if (Input.GetKeyDown(KeyCode.X))
        {
            orbGun.ShootOrb();
        }


    }


}
