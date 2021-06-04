using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="newGradientColorSampler",menuName ="PP Game/Color Samplers/Gradient")]
public class GradientColorSampler : ColorSampler
{

    [SerializeField] Gradient gradient;
    [SerializeField] ColorSwitchMode clolorSwitchMode = ColorSwitchMode.BackAndForward;
    [SerializeField] float switchPeriod = 12.0f;


    public override float GetCurrentSample()
    {
        float sample;

        switch (clolorSwitchMode)
        {
            case ColorSwitchMode.BackAndForward:
                sample = GetSamplefForBackAndForward();
                break;
            case ColorSwitchMode.Loop:
                sample = GetSamplefForLoop();
                break;
            case ColorSwitchMode.ConstBegin:
                sample = 0;
                break;
            default:
                Debug.LogError($"Uncovered {nameof(ColorSwitchMode)} switch statemnet");
                sample = 0;
                break;
        }
        return sample;
    }

    public override Color SampleColor(float sample)
    {
        return gradient.Evaluate(sample);
    }

    float GetSamplefForBackAndForward()
    {
        float sample = Time.time / (switchPeriod * 2);
        sample -= Mathf.Floor(sample);
        sample *= 2;

        if (sample > 1.0f)
        {
            sample = 2.0f - sample;
        }

        return sample;


    }

    float GetSamplefForLoop()
    {
        float sample = Time.time / switchPeriod;
        sample -= Mathf.Floor(sample);

        return sample;

    }

}
