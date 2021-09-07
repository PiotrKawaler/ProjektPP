using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour,IDamageSource
{
    [SerializeField] Collider2D colider;
    [SerializeField] DamagePacket damagePacket;

    private void Awake()
    {
        if (colider == null)
        {
            colider=GetComponent<Collider2D>();
        }
    }

    public Vector2 GetDamagePosition()
    {
        return colider.attachedRigidbody.position;
    }

    public GameObject GetGameObject()
    {
        return colider.attachedRigidbody.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageRecieverBase damageReciever = collision?.attachedRigidbody?.GetComponent<DamageRecieverBase>();

        if (damageReciever != null)
        {
            damageReciever.ReciveDamage(damagePacket, this);
        }
        

    }
}
