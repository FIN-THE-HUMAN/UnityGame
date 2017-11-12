using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyMoving : MonoBehaviour {

    public float speed = 3.0f;
    public int maxLineDistance = 10;
    private float accuracy = 0.1f;
    private WayChangerRandom wayChanger;
    Vector3 direction;

    private bool IsFinishReached(Vector3 finish)
    {
        if(Comparer.IsEqual(transform.position.x, finish.x, accuracy) &&
            Comparer.IsEqual(transform.position.y, finish.y, accuracy))
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
        if (IsFinishReached(wayChanger.Finish) || IsWayBarricatedByWall(direction))
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
            if (Comparer.IsCoordsInteger(transform.position.x, transform.position.y, accuracy))
            {
                SetCoordinates(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
                wayChanger.MakeOldAndNewEqual();
                return DirectionVectorMap.GetVectorByDirection(this.gameObject, wayChanger.NewWay);
            }
            else return _direction;
        }
        else return _direction;  
    }

    private bool IsWayBarricatedByWall(Vector3 way)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, way, 0.5f);
        if (hit)
            return true;
        return false;
    }

    private List<Direction> FreeWays()
    {
        List<Direction> result = new List<Direction>();
        if (!IsWayBarricatedByWall(transform.up))               result.Add(Direction.up);
        if (!IsWayBarricatedByWall(transform.up * -1.0f))       result.Add(Direction.down);
        if (!IsWayBarricatedByWall(transform.right))            result.Add(Direction.right);
        if (!IsWayBarricatedByWall(transform.right * -1.0f))    result.Add(Direction.left);
        return result;
    }
}