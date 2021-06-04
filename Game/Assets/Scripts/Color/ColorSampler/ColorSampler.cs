using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorSampler : ScriptableObject, IColorSampler
{

    /// <summary>
    /// Gets color based on Time.time value
    /// </summary>
    /// <returns></returns>
    public virtual Color GetCurrentColor()
    {
        return SampleColor(GetCurrentSample());
    }
    /// <summary>
    /// Get gruent sample based on Time.time 
    /// </summary>
    /// <returns></returns>
    public abstract float GetCurrentSample();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sample"> Sample in range of 0 to 1</param>
    /// <returns>Sampled Color</returns>
    public abstract Color SampleColor(float sample);
}
