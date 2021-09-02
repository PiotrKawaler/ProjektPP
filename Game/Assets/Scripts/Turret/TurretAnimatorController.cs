using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class TurretAnimatorController : MonoBehaviour
{
    Animator animator;
    ITurretAnimationSource turretAnimationSource;
    void Awake()
    {
        animator = GetComponent<Animator>();
        turretAnimationSource = GetComponent<ITurretAnimationSource>();

        if (turretAnimationSource != null)
        {
            turretAnimationSource.shootEvent += OnShootEvent;
        }

    }

    private void OnDestroy()
    {
        if (turretAnimationSource != null)
        {
            turretAnimationSource.shootEvent -= OnShootEvent;
        }
    }


    private void OnShootEvent()
    {
        animator.SetTrigger("ShootTrigger");
    }


    public void triggerShootCallback()
    {
        turretAnimationSource?.shootAnimCallback();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
