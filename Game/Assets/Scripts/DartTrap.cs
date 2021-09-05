using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrap : MonoBehaviour
{

    [Header("Prefabs")]
    [SerializeField] GameObject arrowPrefab;

    [Header("Transforms")]
    [SerializeField] Transform fireSource;


    [Header("Refrences")]
    [SerializeField] AgroController agroController;

    [Header("Settings")]
    [SerializeField] float shootCooldown=10;
    [SerializeField] float arrowVelocity=5;


    private float lastShootTimestamp=0;

    private void OnEnable()
    {
        if (agroController)
        {
            agroController.onAggroEvent += OnTrapTrigger;
        }
    }

    private void OnDisable()
    {
        if (agroController)
        {
            agroController.onAggroEvent -= OnTrapTrigger;
        }
            
    }

    private void shootArrow()
    {
        GameObject arrowInstance = Instantiate(arrowPrefab, fireSource.position, fireSource.rotation);

        Rigidbody2D rb = arrowInstance.GetComponent<Rigidbody2D>();

        if (rb)
        {
            rb.velocity = fireSource.right * arrowVelocity;
        }


    }

    void OnTrapTrigger(GameObject target)
    {
        float currentTimestamp = Time.time;

        if(currentTimestamp - lastShootTimestamp> shootCooldown)
        {
            shootArrow();
            lastShootTimestamp = currentTimestamp;
        }


    }



}
