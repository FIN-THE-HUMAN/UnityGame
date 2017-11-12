using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomRandom {
    public static System.Random random = new System.Random();
    public static int Next(int start, int end)
    {
        return random.Next(start, end);
    }
}