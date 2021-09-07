using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] Transform spawnPositon;

    [Header("Refrences")]
    [SerializeField]AgroController playerDetection;
    [SerializeField] Animator animator;

    [Header("Settings")]
    [SerializeField] string identifier;
    public string Identifier { get => identifier; }



    public Vector3 SpawnPositon { get => spawnPositon != null ? spawnPositon.position : transform.position; }

    private bool isSelected;


    private void Awake()
    {

        if (playerDetection)
        {
            playerDetection.onAggroEvent += OnPlayerEnter;
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        
    }

    private void OnDestroy()
    {
        if (playerDetection)
        {
            playerDetection.onAggroEvent -= OnPlayerEnter;
        }
    }


    void OnPlayerEnter(GameObject target)
    {

        if (isSelected == false)
        {
            CheckpointManager.Instance?.SetCheckpoint(this);
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.RestoreToFull();
            }
        }
        
    }

    public void SelectCheckpoint()
    {
        animator.SetBool("IsLit", true);
        isSelected = true;
    }

    public void DeselectCheckpoint()
    {
        animator.SetBool("IsLit", false);
        isSelected = false;
    }


}
