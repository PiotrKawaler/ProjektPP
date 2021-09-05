using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectHandler : MonoBehaviour
{

    public GameObject hitEffect;

    void OnTriggerEnter2D(Collider2D collider)
    {
        hitEffectPlay();
    }

    // void OnTriggerExit2D(Collider2D collider)
    // {
    //      if(collider.tag == "Obstacle")
    //     {
    //         Destroy(gameObject);
    //     }
    // }


    // void OnTriggerStay2D(Collider2D collider)
    // {
    //      if(collider.tag == "Obstacle")
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    void hitEffectPlay()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.GetComponent<ParticleSystem>().Play();
        Destroy(effect, 5f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
