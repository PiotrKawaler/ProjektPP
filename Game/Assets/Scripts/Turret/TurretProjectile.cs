using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour,IDamageSource
{

    [SerializeField] private DamagePacket damagePacket;



    public Vector2 GetDamagePosition()
    {
        return transform.position;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageRecieverBase damageReciever = collision?.attachedRigidbody?.GetComponent<DamageRecieverBase>();

        if (damageReciever == null) return;

        if (damageReciever.IsValidTarget(damagePacket, this))
        {
            damageReciever.ReciveDamage(damagePacket, this);
            Destroy(gameObject);
        }
    }
}
