using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectHandler : MonoBehaviour
{

    public GameObject hitEffect;
    public bool pickProjectileColor = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        hitEffectPlay();
    }

    void hitEffectPlay()
    {

        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        if (pickProjectileColor)
        {
            effect.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
        }
        effect.GetComponent<ParticleSystem>().Play();
        Destroy(effect.gameObject, 5f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
