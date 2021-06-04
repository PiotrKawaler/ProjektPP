using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Orb : MonoBehaviour
{
    
    public float orbSlotLerpSpeed =15;

   


    
    public float orbShootLerpSpeed = 15;
    public float orbShootTriggerRadius = 0.3f;


    private float orbShootStrength;

    private Transform orbShootSource;
    private ColorSwitcher colorSwitcher;
    private OrbSlot orbSlot;
    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    
    

    private void Awake()
    {
        colorSwitcher = GetComponent<ColorSwitcher>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    public void UnsubscribeFromOrbslot()
    {
        if (orbSlot == null) return;

        colorSwitcher.defaultColor = orbSlot.GetCurrentColor();

        orbSlot.UnlinkOrb();
        colorSwitcher.samplerBehaviour = null;
        orbSlot = null;
    }

    public void SubscribeToOrbslot(OrbSlot newOrbSlot)
    {
        orbSlot = newOrbSlot;
        orbSlot.LinkOrb(this);

        myRigidbody.isKinematic = true;
        myCollider.enabled = false;

        if (colorSwitcher != null)
        {
            colorSwitcher.samplerBehaviour = orbSlot;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (orbShootSource != null)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                orbShootSource.position,
                Time.deltaTime * orbShootLerpSpeed

            );

            float distSqr = (transform.position - orbShootSource.position).sqrMagnitude;

            if (distSqr < orbShootTriggerRadius * orbShootTriggerRadius)
            {
                TriggerShoot();
            }


            return;
        }



        if (orbSlot != null)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                orbSlot.transform.position,
                Time.deltaTime *  orbSlotLerpSpeed

            );
        }
    }

    public void StartShoot(Transform orbShootSource, float orbShootStrength)
    {
        UnsubscribeFromOrbslot();
        this.orbShootSource = orbShootSource;
        this.orbShootStrength = orbShootStrength;
    }


    private void TriggerShoot()
    {
        myRigidbody.isKinematic = false;
        myCollider.enabled = true;

        myRigidbody.AddForce(orbShootSource.right * orbShootStrength, ForceMode2D.Impulse);
        orbShootSource = null;

    }

    

}
