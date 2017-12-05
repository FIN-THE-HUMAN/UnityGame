using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyMoving : MonoBehaviour {

    public float speed = 3.0f;
    public int maxLineDistance = 10;
    private WayChangerRandom wayChanger;
    Vector3 direction;

    private bool IsFinishReached(Vector3 finish)
    {
        if(Comparer.IsEqual(transform.position.x, finish.x, Constants.Accuracy) &&
            Comparer.IsEqual(transform.position.y, finish.y, Constants.Accuracy))
            return true;
        return false;
    }

    void SetCoordinates(float x, float y)
    {
        transform.position = new Vector3(x, y, transform.position.z);
    }

    void Start()
    {
        direction = Vector3.zero;
        wayChanger = new WayChangerRandom(transform.position, maxLineDistance);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (IsFinishReached(wayChanger.Finish) || MovingUtils.IsWayBarricatedByWall(transform.position, direction))
        {
            wayChanger.TryChangeWay(FreeWays(), transform.position);
            if (wayChanger.IsWayChanged)
                direction = GetVectorDirection(direction);
        }
        else direction = GetVectorDirection(direction);
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    Vector3 GetVectorDirection(Vector3 _direction)
    {
        if (wayChanger.IsWayChanged)
        {
            if (Comparer.IsCoordsInteger(transform.position.x, transform.position.y, Constants.Accuracy))
            {
                SetCoordinates(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
                wayChanger.MakeOldAndNewEqual();
                return DirectionVectorMap.GetVectorByDirection(this.gameObject, wayChanger.NewWay);
            }
            else return _direction;
        }
        else return _direction;  
    }

    private List<Direction> FreeWays()
    {
        List<Direction> result = new List<Direction>();
        if (!MovingUtils.IsWayBarricatedByWall(transform.position, transform.up))               result.Add(Direction.up);
        if (!MovingUtils.IsWayBarricatedByWall(transform.position, transform.up * -1.0f))       result.Add(Direction.down);
        if (!MovingUtils.IsWayBarricatedByWall(transform.position, transform.right))            result.Add(Direction.right);
        if (!MovingUtils.IsWayBarricatedByWall(transform.position, transform.right * -1.0f))    result.Add(Direction.left);
        return result;
    }
}