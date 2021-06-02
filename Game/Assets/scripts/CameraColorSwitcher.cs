using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraColorSwitcher : ColorSwitcher
{
    Camera myCamera;
    private void Awake()
    {
        myCamera = GetComponent<Camera>();
    }
    protected override void SetTargetToColor(Color color)
    {
        myCamera.backgroundColor = color;
    }
}
