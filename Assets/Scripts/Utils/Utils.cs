using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Utils {

    public static Vector3 ToIntVector(this Vector3 v)
    {
        return new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), v.z);
    }
    
    public static string Reverse(this string s)
    {
        StringBuilder result = new StringBuilder();
        for (int i = s.Length - 1; i >= 0; i--)
        {
            result.Append(s[i]);
        }
        return result.ToString();
    }
}