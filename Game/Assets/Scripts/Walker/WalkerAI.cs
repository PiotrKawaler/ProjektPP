using System.Collections;
using System.Collections.Generic;
using UnityEngine;



enum WalkerAIState
{
    Deagro,
    AgroTargetHigh,
    AgroTargetLow,
}


[RequireComponent(typeof(PlayerMover))]
public class WalkerAI : MonoBehaviour
{

    [Header("Transforms")]
    [SerializeField]private Transform playerAltiudeCompare=null;
    [SerializeField] private Transform triggerJumpCheck = null;

    public float checkRadius = 0.1f;

    [Header("Refrences")]
    [SerializeField] private AgroController agroController;


    [Header("Agro State")]
    public float minSeparationDistance = 0.15f;
    public float minJumpInterval = 1.5f;
    public float maxJumpInterval = 4;

    

    PlayerMover playerMover;
    GameObject currentTarget;
    WalkerAIState currentState;


    private float jumpCountdown;


    private void Awake()
    {
        playerMover = GetComponent<PlayerMover>();

        if (agroController != null)
        {
            agroController.onAggroEvent += OnAgro;
            agroController.onDeaggroEvent += OnDeagro;
        }
    }

    private void OnDestroy()
    {
        if (agroController!= null)
        {
            agroController.onAggroEvent -= OnAgro;
            agroController.onDeaggroEvent -= OnDeagro;
        }
    }

    private void OnAgro(GameObject target)
    {
        if (currentTarget == null)
        {
            currentTarget = target;
        }
    }

    private void OnDeagro(GameObject target)
    {
        if (currentTarget == target)
        {
            currentTarget = null;
        }
    }

    WalkerAIState caclCurrentState()
    {
        if (currentTarget == null)
        {
            return WalkerAIState.Deagro;
        }
        else
        {
            if(currentTarget.transform.position.y> playerAltiudeCompare.position.y)
            {
                return WalkerAIState.AgroTargetHigh;
            }
            else
            {
                return WalkerAIState.AgroTargetLow;
            }
        }

    }

    void doUpdateForState(WalkerAIState state)
    {
        switch (state)
        {
            case WalkerAIState.Deagro:
                doUpdateForDeagro();
                break;
            case WalkerAIState.AgroTargetHigh:
                doUpdateForAgroTargetHigh();
                break;
            case WalkerAIState.AgroTargetLow:
                doUpdateForAgroTargetLow();
                break;
            default:
                break;
        }
        
    }



    
    void doUpdateForDeagro()
    {
        playerMover.ReadInputs(0, false);
    }

    void doUpdateForAgroTargetLow()
    {
        if (currentTarget == null) return;
        //jumpCountdown -= Time.deltaTime;
        float xDir = currentTarget.transform.position.x - transform.position.x;
        float moveInput = (Mathf.Abs(xDir) < minSeparationDistance) ? 0 : Mathf.Sign(xDir);
        playerMover.ReadInputs(moveInput, false);
    }

    void doUpdateForAgroTargetHigh()
    {
        if (currentTarget == null) return;
        float xDir = currentTarget.transform.position.x - transform.position.x;

        float moveInput = (Mathf.Abs(xDir) < minSeparationDistance) ? 0 : Mathf.Sign(xDir);
        bool jumnpInput = false;

        jumpCountdown -= Time.deltaTime;


        if (playerMover.IsGrounded())
        {
            //Jump if at the edge
            int groundLayers = playerMover.GroundLayers.value;

            var hit = Physics2D.CircleCast(triggerJumpCheck.position, checkRadius, Vector2.zero, 0, groundLayers);

            if (hit.collider == null)
            {
                jumnpInput = true;
            }

            //Random jump based on interval
            if (jumpCountdown <= 0)
            {
                jumnpInput = true;
                jumpCountdown = Random.Range(minJumpInterval, maxJumpInterval);
            }


        }
        playerMover.ReadInputs(moveInput, jumnpInput);

    }






    private void Update()
    {
        currentState = caclCurrentState();
        doUpdateForState(currentState);
    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;


        if (playerAltiudeCompare != null)
        {
            Gizmos.DrawWireSphere(playerAltiudeCompare.position, checkRadius);
        }
        if (triggerJumpCheck != null)
        {
            Gizmos.DrawWireSphere(triggerJumpCheck.position, checkRadius);
        }


    }


}
