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
    public float projectileVelocity=7;
    public float shootColdown = 3;
    public float angleLerpSpeed = 9;

    private float lastShootTimestamp;

    private Quaternion targetRotation;


    private void Awake()
    {
        lastShootTimestamp = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        cannonPivot.rotation = Quaternion.Lerp(
            cannonPivot.rotation,
            targetRotation,
            angleLerpSpeed * Time.deltaTime
            );
    }

    public void SetTarget(Vector3 target)
    {
        Vector3 dir = target - cannonPivot.position;

        Vector3 dirUp = new Vector3(-dir.y, dir.x, 0);

        Quaternion rot =Quaternion.LookRotation(Vector3.forward, dirUp);
        targetRotation = rot;
        
    }

    ///Returns false if shoot on coldown
    public bool Shoot()
    {

        if(Time.timeSinceLevelLoad - lastShootTimestamp > shootColdown)
        {
            lastShootTimestamp = Time.timeSinceLevelLoad;
            shootEvent?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
        


        
    }



    private void shootBullet()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, shooTransform.position, shooTransform.rotation);

        var rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.velocity=projectileVelocity * shooTransform.right;
    }


    

    public void shootAnimCallback()
    {
        shootBullet();
    }
}
