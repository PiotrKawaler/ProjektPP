using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ColorSwitchMode
{
    BackAndForward,
    Loop,
    ConstBegin
}



public abstract class ColorSwitcher : MonoBehaviour
{



    [SerializeField] Gradient gradient;
    [SerializeField] ColorSwitchMode clolorSwitchMode=ColorSwitchMode.BackAndForward;
    [SerializeField] float switchPeriod = 12.0f;


    protected abstract void SetTargetToColor(Color color);


    Color GetColorfForBackAndForward()
    {
        float sample = Time.time / (switchPeriod*2);
        sample -= Mathf.Floor(sample);
        sample *= 2;

        if (sample > 1.0f)
        {
            sample = 2.0f - sample;
        }

        return gradient.Evaluate(sample);


    }

    Color GetColorfForLoop()
    {
        float sample = Time.time / switchPeriod;
        sample -= Mathf.Floor(sample);

        return gradient.Evaluate(sample);

    }

    private void Update()
    {
        Color color;

        switch (clolorSwitchMode)
        {
            case ColorSwitchMode.BackAndForward:
                color = GetColorfForBackAndForward();
                break;
            case ColorSwitchMode.Loop:
                color = GetColorfForLoop();
                break;
            case ColorSwitchMode.ConstBegin:
                color = gradient.Evaluate(0);
                break;
            default:
                color=Color.black;
                break;
        }


        SetTargetToColor(color);


    }


}
