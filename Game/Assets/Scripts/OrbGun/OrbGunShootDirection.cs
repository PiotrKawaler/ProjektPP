using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGunShootDirection : MonoBehaviour
{

    [SerializeField] Transform orbFireSource;

    //-1 0 1
    //left/down center right/up

    private int  currentHorizontal =1;
    private int currentVertical = 0;
    public void SetShootAxis(int horizontal, int vertical)
    {
        if(orbFireSource == null)
        {
            Debug.LogWarning($"Asign shoot transform in ${nameof(OrbGunShootDirection)}");
            return;
        }

        currentHorizontal = horizontal == 0 ? currentHorizontal : horizontal;
        currentVertical = vertical;

        setFireDirection();
    }

    void setFireDirection()
    {

        Quaternion rot = Quaternion.LookRotation(Vector3.forward, new Vector3(-currentVertical*0.6f, currentHorizontal));
        orbFireSource.rotation = rot;

    }





}
