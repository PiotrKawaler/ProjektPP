using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class TilemapColorSwitcher : ColorSwitcher
{


    Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    protected override void SetTargetToColor(Color color)
    {
        tilemap.color = color;
    }

}
