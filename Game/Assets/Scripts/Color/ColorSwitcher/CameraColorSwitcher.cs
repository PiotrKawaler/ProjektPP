using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraColorSwitcher : ColorSwitcher
{
    Camera myCamera;
    protected override void SetTargetToColor(Color color)
    {
        if (myCamera == null)
        {
            myCamera = GetComponent<Camera>();
        }
        myCamera.backgroundColor = color;
    }
}
