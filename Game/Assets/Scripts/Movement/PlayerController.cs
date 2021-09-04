using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(OrbGun))]
[RequireComponent(typeof(OrbGunShootDirection))]
public class PlayerController : MonoBehaviour
{

    PlayerMover playerMover;
    OrbGun orbGun;
    OrbGunShootDirection gunDirection;

    private void Awake()
    {
        playerMover = GetComponent<PlayerMover>();
        orbGun = GetComponent<OrbGun>();
        gunDirection = GetComponent<OrbGunShootDirection>();
    }




    private void Update()
    {
        bool jumpPressed = Input.GetKey(KeyCode.Space)| Input.GetKey(KeyCode.Z);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");



        gunDirection.SetShootAxis((int)horizontal, (int)vertical);

        playerMover.ReadInputs(horizontal, jumpPressed);

        if (Input.GetKeyDown(KeyCode.X))
        {
            orbGun.ShootOrb();
        }


    }


}
