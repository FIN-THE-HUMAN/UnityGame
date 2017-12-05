using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionVectorMap {

    public static Vector3 GetVectorByDirection(GameObject entity, Direction _dir)
    {
        switch (_dir)
        {
            case Direction.up: return entity.transform.up;
            case Direction.down: return entity.transform.up * -1.0f;
            case Direction.right: return entity.transform.right;
            case Direction.left: return entity.transform.right * -1.0f;
        }
        return Vector3.zero;
    }
}