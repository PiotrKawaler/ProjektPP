using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainerUI : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void setFilled(bool isFilled)
    {
        animator?.SetBool("isFilled", isFilled);
    }




}
