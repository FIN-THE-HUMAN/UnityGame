using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovingUtils  {

    public static bool IsWayBarricatedByWall(Vector3 position, Vector3 way)
    {
        if (Comparer.IsCoordsInteger(position, Constants.Accuracy))
        {
            RaycastHit2D hit = Physics2D.Raycast(position, way, 0.5f);
            if (hit) return true;
            return false;
        }
        return false;
    }

}
