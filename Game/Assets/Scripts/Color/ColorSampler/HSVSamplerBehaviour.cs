using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HSVSamplerBehaviour : ColorSamplerBehaviour
{
    [Header("HSV Color Sampler")]
    public Color BaseColor = Color.red;
    public bool IsHSVClockWise=true;


    sealed public override Color SampleColor(float sample)
    {
        float h, s,v;
        Color.RGBToHSV(BaseColor,out h, out s, out v);

        if (IsHSVClockWise)
        {
            h += sample;
            if (h >= 1) h -= 1;
        }
        else
        {
            h -= sample;
            if (h < 0) h += 1;
        }

        return Color.HSVToRGB(h, s, v);

    }

    public void SetupBaseColor(Color newBaseColor, float offset=0,bool isClockwise=true)
    {
        IsHSVClockWise = isClockwise;

        float h, s, v;
        Color.RGBToHSV(newBaseColor, out h, out s, out v);

        if (IsHSVClockWise)
        {
            h += offset;
            if (h >= 1) h -= 1;
        }
        else
        {
            h -= offset;
            if (h < 0) h += 1;
        }

        BaseColor =  Color.HSVToRGB(h, s, v);
    }


}
