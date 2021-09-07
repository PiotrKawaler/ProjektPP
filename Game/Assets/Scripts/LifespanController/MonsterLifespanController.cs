using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLifespanController : MonoBehaviour
{
    [Tooltip("Wait for death ainms to finish")]
    [SerializeField] private float cleanupTime = 0;
    [SerializeField] private GameObject deathParticleEffect;

    IDeathEventCaller deathEventCaller;
    private void Awake()
    {
        deathEventCaller = GetComponent<IDeathEventCaller>();
        if (deathEventCaller != null)
            deathEventCaller.DeathEvent += OnDeath;
    }

    void OnDeath()
    {
        deathEventCaller.DeathEvent -= OnDeath;
        deathEffectPlay();
        Destroy(gameObject, cleanupTime);
    }


    //death effect
    private void deathEffectPlay()
    {
        GameObject effect = Instantiate(deathParticleEffect, transform.position, transform.rotation);
        effect.GetComponent<ParticleSystem>().Play();
        Destroy(effect.gameObject, 5f);
    }
}
