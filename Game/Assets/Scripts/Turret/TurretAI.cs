using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TurretController))]
public class TurretAI : MonoBehaviour
{

    private TurretController turretController;

    // Start is called before the first frame update
    void Awake()
    {
        turretController = GetComponent<TurretController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            turretController.Shoot();
        }

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        turretController.SetTarget(worldPos);


    }
}
