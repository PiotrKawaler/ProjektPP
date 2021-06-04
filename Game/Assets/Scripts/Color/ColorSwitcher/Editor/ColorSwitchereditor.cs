using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ColorSwitcher), true)]

public class ColorSwitchereditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ColorSwitcher switcher = (ColorSwitcher)target;

        

        




        if (GUILayout.Button("Preview"))
        {

            switcher.OnPrviewButton();
        }

    }
}
