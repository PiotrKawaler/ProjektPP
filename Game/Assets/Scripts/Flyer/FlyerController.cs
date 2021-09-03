using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerController : MonoBehaviour
{

    [Header("Refrences")]
    [SerializeField] AgroController agroController=null;

    [Header("Settings")]
    public float flyingSpeed=2.5f;
    public float speedChange=4;



    Rigidbody2D rigidbody2d;
    Vector2 velocityTarget;

    private GameObject currentTarget = null;


    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        if (agroController!=null)
        {

            agroController.onAggroEvent += OnAggro;
            agroController.onDeaggroEvent += OnDeaggro;
        }

    }

    private void OnDestroy()
    {
        if (agroController!=null)
        {
            agroController.onAggroEvent -= OnAggro;
            agroController.onDeaggroEvent -= OnDeaggro;
        }
    }

    private void OnAggro(GameObject target)
    {
        
        if (currentTarget == null)
        {
            currentTarget = target;
        }
    }

    private void OnDeaggro(GameObject target)
    {
        if (currentTarget == target)
        {

            currentTarget = null;
        }
    }


    private void FixedUpdate()
    {

        if (currentTarget == null)
        {
            velocityTarget = Vector2.zero;
        }
        else
        {
            Vector3 dir = currentTarget.transform.position - transform.position;

            dir.Normalize();
            dir *= flyingSpeed;

            velocityTarget = dir;
        }

        rigidbody2d.velocity = Vector2.Lerp(
             rigidbody2d.velocity,
             velocityTarget,
             speedChange * Time.deltaTime
            );
    }



}
