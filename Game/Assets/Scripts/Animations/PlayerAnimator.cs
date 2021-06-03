using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerAnimator : MonoBehaviour
{
    [Header("Refrences")]
    IPlayerAnimatorController playerAnimatorController;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D myRigidbody;


    [Header("Paramaters")]
    [Range(0,0.5f)]
    float walkingSpeedTreshold = 0.05f;


    // Start is called before the first frame update
    private void Awake()
    {
        
        

        if (animator == null)
        {
            animator =  GetComponent<Animator>();
        }

        if (animator == null)
        {
            Debug.LogWarning($"{nameof(PlayerAnimator)} Requiers ${nameof(Animator)} reference or component");
            this.enabled = false;
        }


        playerAnimatorController = GetComponent<IPlayerAnimatorController>();

        if (playerAnimatorController==null)
        {
            Debug.LogWarning($"{nameof(PlayerAnimator)} Requiers ${nameof(IPlayerAnimatorController)} component");
            this.enabled = false;
        }



        if (myRigidbody == null)
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }

        if (myRigidbody == null)
        {
            Debug.LogWarning($"{nameof(PlayerAnimator)} Requiers ${nameof(Rigidbody2D)} reference or component");
            this.enabled = false;
        }


    }

    private void OnEnable()
    {
        playerAnimatorController.PlayerJumpedEvent += OnJump;
    }
    private void OnDisable()
    {
        playerAnimatorController.PlayerJumpedEvent -= OnJump;
    }


    private void OnJump()
    {
        animator.SetTrigger("JumpTrigger");
    }


    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsGrounded",playerAnimatorController.IsGrounded());


        bool isWalking = Mathf.Abs( myRigidbody.velocity.x )>  walkingSpeedTreshold;

        animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            animator.SetBool("isFlipped", myRigidbody.velocity.x < 0);
        }

    }
}
