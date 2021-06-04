using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorSamplerBehaviour : MonoBehaviour, IColorSampler
{
    public virtual Color GetCurrentColor()
    {
        return SampleColor(GetCurrentSample());
    }
    public abstract float GetCurrentSample();
    public abstract Color SampleColor(float sample);
}
