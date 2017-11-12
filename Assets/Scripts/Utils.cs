using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static Vector3 ToIntVector(this Vector3 v)
    {
        return new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), v.z);
    }
}