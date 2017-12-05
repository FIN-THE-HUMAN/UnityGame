using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Comparer {

    public static bool IsEqual(float a, float b, float accuracy)
    {
        return Mathf.Abs(a - b) < accuracy;
    }

    public static bool IsInteger(float c, float accuracy)
    {
        if (Mathf.Abs(Mathf.Round(c) - c) < accuracy)
            return true;
        return false;
    }

    public static bool IsCoordsInteger(float x, float y, float accuracy)
    {
        if (IsInteger(x, accuracy) && IsInteger(y, accuracy))
            return true;
        return false;
    }

    public static bool IsCoordsInteger(Vector3 v, float accuracy)
    {
        if (IsInteger(v.x, accuracy) && IsInteger(v.y, accuracy))
            return true;
        return false;
    }

    public static bool IsVectorEqual(Vector3 v1, Vector3 v2)
    {
        v1 = v1.ToIntVector();
        v2 = v2.ToIntVector();
        if (v1.x == v2.x && v1.y == v2.y)
            return true;
        return false;
    }
}