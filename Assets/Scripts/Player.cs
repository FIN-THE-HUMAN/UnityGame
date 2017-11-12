using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    private float accuracy = 0.1f;
    private WayChangerPlayer wayChanger;
    Vector3 direction;

    private bool AnyButtonTap()
    {
        if (Input.GetButton("Horizontal"))
            return true;
        if (Input.GetButton("Vertical"))
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
        wayChanger = new WayChangerPlayer();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (AnyButtonTap()) wayChanger.TryChangeWay();
        if(IsWayBarricatedByWall(direction))
        {
            if (wayChanger.IsWayChanged) direction = GetVectorDirection(direction); 
            else direction = Vector3.zero;
        }
        else
        direction = GetVectorDirection(direction);
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
        if(hit) return true;
        return false;
    }
}