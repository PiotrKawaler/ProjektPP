using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour, IPlayerAnimatorController
{

    [Header("Parameters")]
    public float speed=2;
    public float jumpStrength = 6;

    [Header("Points")]
    public Transform GroundCheck;


    [Header("Masks")]
    [SerializeField]private LayerMask groundLayers;
    public LayerMask GroundLayers { get => groundLayers; }

    [Header("Tweaks")]
    [SerializeField] private float groundCheckRadius=0.2f;



    Rigidbody2D myRigidbody;

    float movementInput;
    bool jumpPressedInput;


    

    bool isGrounded;
    
    public event Action PlayerJumpedEvent;

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public void ReadInputs(float movment, bool jumpPressed)
    {
        movementInput = movment;
        jumpPressedInput = jumpPressed;
    }


    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        if (GroundCheck == null)
        {
            GroundCheck = transform;
        }
    }


    private void FixedUpdate()
    {
        Collider2D  ground =  Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, groundLayers);

        isGrounded = ground != null&& myRigidbody.velocity.y<=0.02;

        myRigidbody.velocity = new Vector2(movementInput * speed, myRigidbody.velocity.y);

        if (isGrounded && jumpPressedInput)
        {
            PlayerJumpedEvent?.Invoke();
            myRigidbody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(GroundCheck?.position ?? transform.position, groundCheckRadius);
    }



}
