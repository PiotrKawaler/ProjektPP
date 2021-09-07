using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct SpikeDamageSource : IDamageSource
{

    public Vector2 pos;

    public Vector2 GetDamagePosition()
    {
        return pos;
    }

    public GameObject GetGameObject()
    {
        return null;
    }
}


public class SpikeTilemap : MonoBehaviour
{


    [SerializeField] DamagePacket damagePacket;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rigidbody2D = collision?.attachedRigidbody;

        if (rigidbody2D == null) return;

        DamageRecieverBase damageReciever = rigidbody2D?.GetComponent<DamageRecieverBase>();
        if (damageReciever == null) return;

        damageReciever.ReciveDamage(damagePacket, new SpikeDamageSource { pos = rigidbody2D.position });


    }





}
