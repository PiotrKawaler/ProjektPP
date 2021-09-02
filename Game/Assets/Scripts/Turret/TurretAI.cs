using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TurretController))]
public class TurretAI : MonoBehaviour
{

    [SerializeField] AgroController agroController;


    private TurretController turretController;

    private GameObject agroTarget;
  
    void Awake()
    {
        turretController = GetComponent<TurretController>();



        if(agroController != null)
        {
            agroController.onAggroEvent += OnAggro;
            agroController.onDeaggroEvent += OnDeagro;
        }
    }

    private void OnDestroy()
    {
        if (agroController != null)
        {
            agroController.onAggroEvent -= OnAggro;
            agroController.onDeaggroEvent -= OnDeagro;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (agroTarget == null) return;


        turretController.Shoot();
        turretController.SetTarget(agroTarget.transform.position);


    }


    private void OnAggro(GameObject target)
    {
        if (agroTarget == null)
        {
            agroTarget = target;
        }
    }

    private void OnDeagro(GameObject target)
    {
        if(agroTarget == target)
        {
            agroTarget = null;
        }
    }

}
