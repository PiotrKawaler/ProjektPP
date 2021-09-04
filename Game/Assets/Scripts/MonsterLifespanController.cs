using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLifespanController : MonoBehaviour
{
    [Tooltip("Wait for death ainms to finish")]
    [SerializeField] private float cleanupTime = 0;

    IDeathEventCaller deathEventCaller;
    private void Awake()
    {
        deathEventCaller = GetComponent<IDeathEventCaller>();
        deathEventCaller.DeathEvent += OnDeath;
    }

    void OnDeath()
    {
        deathEventCaller.DeathEvent -= OnDeath;
        Destroy(gameObject, cleanupTime);
    }

}
