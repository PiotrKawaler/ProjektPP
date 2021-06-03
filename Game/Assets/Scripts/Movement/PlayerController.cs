using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour
{

    PlayerMover playerMover;

    private void Awake()
    {
        playerMover = GetComponent<PlayerMover>();
    }




    private void Update()
    {
        bool jumpPressed = Input.GetKey(KeyCode.Space)| Input.GetKey(KeyCode.Z);
        float horizontal = Input.GetAxisRaw("Horizontal");

        playerMover.ReadInputs(horizontal, jumpPressed);



    }


}
