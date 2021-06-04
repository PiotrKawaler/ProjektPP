using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHsvSampler : HSVSamplerBehaviour
{
    public override float GetCurrentSample()
    {
        return transform.eulerAngles.z / 360.0f;
    }
}
