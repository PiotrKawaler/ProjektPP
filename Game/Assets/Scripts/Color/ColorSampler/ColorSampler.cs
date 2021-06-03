using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorSampler : ScriptableObject
{

    /// <summary>
    /// Gets color based on Time.time value
    /// </summary>
    /// <returns></returns>
    public abstract Color GetCurrentColor();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sample"> Sample in range of 0 to 1</param>
    /// <returns>Sampled Color</returns>
    public abstract Color SampleColor(float sample);
}
