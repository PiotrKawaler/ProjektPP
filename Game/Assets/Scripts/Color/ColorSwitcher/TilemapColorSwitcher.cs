using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class TilemapColorSwitcher : ColorSwitcher
{


    Tilemap tilemap;


    protected override void SetTargetToColor(Color color)
    {
        if (tilemap == null)
        {
            tilemap = GetComponent<Tilemap>();
        }
        tilemap.color = color;
    }

}
