using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Comparer {

    public static bool IsEqual(float a, float b, float Accuracy)
    {
        if (Mathf.Abs(a - b) < Accuracy)
            return true;
        return false;
    }

    public static bool IsInteger(float c, float Accuracy)
    {
        if (Mathf.Abs(Mathf.Round(c) - c) < Accuracy)
            return true;
        return false;
    }

    public static bool IsCoordsInteger(float x, float y, float accuracy)
    {
        if (IsInteger(x, accuracy) && IsInteger(y, accuracy))
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