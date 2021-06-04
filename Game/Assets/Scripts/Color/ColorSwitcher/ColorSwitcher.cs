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

    public Color defaultColor = Color.white;

    public IColorSampler currentSampler { get  { return (IColorSampler)samplerBehaviour ?? sampler; } }

    public ColorSampler sampler;
    public ColorSamplerBehaviour samplerBehaviour;



    protected abstract void SetTargetToColor(Color color);


    public void OnPrviewButton() {
        if (currentSampler == null)
        {
            SetTargetToColor(defaultColor);
        }
        else
        {
            SetTargetToColor(currentSampler.SampleColor(0));
        }
    }

    private void Update()
    {

        if (currentSampler == null)
        {
            SetTargetToColor(defaultColor);
        }
        else
        {
            SetTargetToColor(currentSampler.GetCurrentColor());
        }
        


    }


}
