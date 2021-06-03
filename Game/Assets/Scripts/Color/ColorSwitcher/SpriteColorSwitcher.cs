using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteColorSwitcher : ColorSwitcher
{

    SpriteRenderer spriteRenderer;
    protected override void SetTargetToColor(Color color)
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        spriteRenderer.color = color;
    }
}
