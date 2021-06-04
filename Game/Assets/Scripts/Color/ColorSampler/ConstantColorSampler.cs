using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newConstatantColorSampler", menuName = "PP Game/Color Samplers/Constant")]
public class ConstantColorSampler : ColorSampler
{

    [SerializeField] Color color = Color.white;
    public override Color GetCurrentColor()
    {
        return color;
    }

    public override float GetCurrentSample()
    {
        return 0;
    }

    public override Color SampleColor(float sample)
    {
        return color;
    }
}
