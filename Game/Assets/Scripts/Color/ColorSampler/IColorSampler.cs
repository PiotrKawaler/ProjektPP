using UnityEngine;
using System;


public interface IColorSampler
{
    Color GetCurrentColor();
    float GetCurrentSample();
    Color SampleColor(float sample);
}