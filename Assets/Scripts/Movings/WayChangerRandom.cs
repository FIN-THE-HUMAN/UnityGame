using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayChangerRandom : AbstractWayChanger {

    public Vector3 Finish { get; private set; }
    public int MaxLineDistance { get; private set; }

    public WayChangerRandom(Vector3 finish, int maxLineDistance)
    {
        Finish = finish;
        MaxLineDistance = maxLineDistance;
    }

    private Vector3 GetFinish(Vector3 start)
    {
        switch(NewWay)
        {
            case Direction.none: return new Vector3(start.x + CustomRandom.Next(-MaxLineDistance, MaxLineDistance), start.y, start.z);
            case Direction.left: return new Vector3(start.x - CustomRandom.Next(1, MaxLineDistance), start.y, start.z);
            case Direction.right:return new Vector3(start.x + CustomRandom.Next(1, MaxLineDistance), start.y, start.z);
            case Direction.up:   return new Vector3(start.x, start.y + CustomRandom.Next(1, MaxLineDistance), start.z);
            case Direction.down: return new Vector3(start.x, start.y - CustomRandom.Next(1, MaxLineDistance), start.z);
        }
        return new Vector3(start.x + CustomRandom.Next(-MaxLineDistance, MaxLineDistance), start.y, start.z);
    }

    protected Direction GetDir(List<Direction> freeWays)
    {
        if(freeWays != null && freeWays.Count != 0)
        {
            return freeWays[CustomRandom.Next(0,freeWays.Count)];
        }
        return Direction.none;
    }

    public void TryChangeWay(List<Direction> freeWays, Vector3 start)
    {
        NewWay = GetDir(freeWays);
        Finish = GetFinish(start);
        if (NewWay != OldWay) IsWayChanged = true;
    }
}