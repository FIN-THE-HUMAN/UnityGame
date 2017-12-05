using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Vector2Int
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector2Int(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}