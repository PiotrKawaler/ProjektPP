using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DamageRecieverBase))]
[RequireComponent(typeof(Rigidbody2D))]
public class KnockbackReciever : MonoBehaviour
{

    [SerializeField] Transform knockbackCenter=null;

    public float knockbackBaseStrength = 5;
    private DamageRecieverBase damageReciever;
    private Rigidbody2D rigidbody2d;
    private void Awake()
    {
        damageReciever = GetComponent<DamageRecieverBase>();
        rigidbody2d = GetComponent<Rigidbody2D>();

       

    }
    private void OnEnable()
    {
        if (damageReciever)
        {
            damageReciever.RecivedDamageEvent += OnRecievedDamage;
        }
    }

    private void OnDisable()
    {
        if (damageReciever)
        {
            damageReciever.RecivedDamageEvent -= OnRecievedDamage;
        }
    }


    private void OnRecievedDamage(DamagePacket packet,IDamageSource source )
    {
        if (rigidbody2d == null) return;


        Transform baseTransform = knockbackCenter != null ? knockbackCenter : transform;

        Vector2 forcedir = (Vector2)baseTransform.position - source.GetDamagePosition();

        forcedir.Normalize();
        

        Vector2 knockBackVector = (forcedir * 0.3f + Vector2.up * 0.7f) * knockbackBaseStrength;


        if (rigidbody2d.isKinematic)
        {
            rigidbody2d.velocity += knockBackVector;
        }
        else
        {
            rigidbody2d.AddForce(knockBackVector, ForceMode2D.Impulse);
        }

        

    }

}
