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
    public ColorSampler sampler;
  
    protected abstract void SetTargetToColor(Color color);


    public void OnPrviewButton() {
        if (sampler == null)
        {
            SetTargetToColor(defaultColor);
        }
        else
        {
            SetTargetToColor(sampler.SampleColor(0));
        }
    }

    private void Update()
    {

        if (sampler==null)
        {
            SetTargetToColor(defaultColor);
        }
        else
        {
            SetTargetToColor(sampler.GetCurrentColor());
        }
        


    }


}
