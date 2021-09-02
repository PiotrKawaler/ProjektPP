using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class AgroController : MonoBehaviour
{
    

    public event Action<GameObject> onAggroEvent;
    public event Action<GameObject> onDeaggroEvent;

    [SerializeField]private Identity agroFilter;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherRB = collision.attachedRigidbody;

        if (otherRB == null) return;
        var otherIdentifier = otherRB.GetComponent<Identifier>();

        if (otherIdentifier == null) return;


        int flagResult = (int)agroFilter & (int)otherIdentifier.Identity;
        if (flagResult != 0)
        {
            onAggroEvent?.Invoke(otherIdentifier.gameObject);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var otherRB = collision.attachedRigidbody;

        if (otherRB == null) return;
        var otherIdentifier = otherRB.GetComponent<Identifier>();

        if (otherIdentifier == null) return;


        int flagResult = (int)agroFilter & (int)otherIdentifier.Identity;
        if (flagResult != 0)
        {
            onDeaggroEvent?.Invoke(otherIdentifier.gameObject);
        }


    }


}
