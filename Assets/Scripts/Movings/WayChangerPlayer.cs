using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayChangerPlayer : AbstractWayChanger
{
    private float Axis(string axis)
    {
        if (Input.GetAxis(axis) >= 0)
            return 1.0f;
        if (Input.GetAxis(axis) < 0)
            return -1.0f;
        return 0;
    }

    private Direction GetDirFromAxis(string axisName)
    {
        if (axisName == "Horizontal")
        {
            if (Axis("Horizontal") >= 0)
                return Direction.right;
            else return Direction.left;
        }
        else if (axisName == "Vertical")
        {
            if (Axis("Vertical") >= 0)
                return Direction.up;
            else return Direction.down;
        }
        return Direction.none;
    }

    protected override Direction GetDir()
    {
        if (Input.GetButton("Horizontal")) return GetDirFromAxis("Horizontal");
        if (Input.GetButton("Vertical")) return GetDirFromAxis("Vertical");
        Debug.Log("Direction.none");
        return Direction.none;
    }
}

