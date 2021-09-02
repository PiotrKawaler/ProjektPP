using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleController : MonoBehaviour
{

    [Header("Transforms")]
    [SerializeField] private Transform directionTransform = null;
    [SerializeField] private Transform wallCheck = null;
    [SerializeField] private Transform groundUnderCheck = null;
    [SerializeField] private Transform groundInFrontCheck = null;

    [Header("Settings")]
    [SerializeField] float movementSpeed = 3;
    [SerializeField] float checkRadius = 0.15f;


    [SerializeField] LayerMask walkableLayers;




    private Rigidbody2D rb;
    private bool isTurnedRight = true;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private bool doFallCheck()
    {

        RaycastHit2D hit;
        //Chek if falling 
        hit = Physics2D.CircleCast(groundUnderCheck.position, checkRadius, Vector2.zero, 0, walkableLayers.value);
        if (hit.collider == null) return true;
        return false;
    }


    private bool doTurnChecks()
    {




        RaycastHit2D hit;
        //Chek if is going to hit the wall
        hit = Physics2D.CircleCast(wallCheck.position, checkRadius, Vector2.zero, 0, walkableLayers.value);
        if (hit.collider != null) return true;

        //Check if ground in front
        hit = Physics2D.CircleCast(groundInFrontCheck.position, checkRadius, Vector2.zero, 0, walkableLayers.value);
        if (hit.collider == null) return true;

        return false;
    }


    Vector2 getDirVector()
    {
        return isTurnedRight ? Vector2.right : Vector2.left;
    }

    private void turnArround()
    {
        isTurnedRight = !isTurnedRight;
        directionTransform.localScale = isTurnedRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);


    }




    private void FixedUpdate()
    {


        if (doFallCheck() == true)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            if (doTurnChecks())
            {
                turnArround();
            }


            rb.velocity = getDirVector() * movementSpeed;
        }
       
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        

        if (wallCheck != null)
        {
            Gizmos.DrawWireSphere(wallCheck.position, checkRadius);
        }
        if (groundInFrontCheck != null)
        {
            Gizmos.DrawWireSphere(groundInFrontCheck.position, checkRadius);
        }
        if (groundUnderCheck != null)
        {
            Gizmos.DrawWireSphere(groundUnderCheck.position, checkRadius);
        }

    }


}
