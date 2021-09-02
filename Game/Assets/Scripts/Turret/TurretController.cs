using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour, ITurretAnimationSource
{

    public event Action shootEvent;


    [Header("Prefabs")]
    [SerializeField]  private GameObject bulletPrefab=null;

    [Header("Transforms")]
    [SerializeField] private Transform cannonPivot=null;
    [SerializeField] private Transform shooTransform=null;

    [Header("Settings")]
    public float shootForce=5;

    

    public void SetTarget(Vector3 target)
    {
        Vector3 dir = target - cannonPivot.position;

        Vector3 dirUp = new Vector3(-dir.y, dir.x, 0);

        Quaternion rot =Quaternion.LookRotation(Vector3.forward, dirUp);
        cannonPivot.rotation = rot;
    }



    private void shootBullet()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, shooTransform.position, shooTransform.rotation);

        var rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.velocity=shootForce * shooTransform.right;
    }


    ///Returns false if shoot on coldown
    public bool Shoot()
    {
        shootEvent?.Invoke();
        return true;
    }

    public void shootAnimCallback()
    {
        shootBullet();
    }
}
