using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractWayChanger
{
    public bool IsWayChanged { get; protected set; }
    public Direction OldWay { get; protected set; }
    public Direction NewWay { get; protected set; }

    public AbstractWayChanger()
    {
        IsWayChanged = false;
        OldWay = Direction.none;
        NewWay = Direction.none;
    }

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

    protected virtual Direction GetDir()
    {
        return Direction.none;
    }

    public void TryChangeWay()
    {
        NewWay = GetDir();
        if (NewWay != OldWay) IsWayChanged = true;
    }

    public void MakeOldAndNewEqual()
    {
        OldWay = NewWay;
        IsWayChanged = false;
    }

}
