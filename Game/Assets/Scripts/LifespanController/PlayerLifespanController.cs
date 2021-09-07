using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifespanController : MonoBehaviour
{
    [Tooltip("Wait for death ainms to finish")]
    [SerializeField] private float cleanupTime = 5;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      

    }


}

