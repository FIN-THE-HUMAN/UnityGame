using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDictionary : MonoBehaviour{

    public GameObject CellPrefab;
    public GameObject WallPrefab;

    public GameObject Player;
    public GameObject Enemy;
    //public GameObject WallPrefabCenter;
    //public GameObject WallPrefabSide;
    public GameObject WallPrefabConer;
    public GameObject WinFieldPrefab;
    public GameObject Bonus;
    //public GameObject Level;    //рычаг

    public void InstantiateFromChar(char i, Vector3 vector)
    {
        switch (i)
        {
            case '0': Instantiate(CellPrefab, vector, Quaternion.identity); break;
            case '1': Instantiate(WallPrefab, vector, Quaternion.identity); break;
            //case '2': Instantiate(WallPrefabCenter, vector, Quaternion.identity); break;

            //case '3': Instantiate(WallPrefabSide, vector, Quaternion.identity); break;
            //case '4': Instantiate(WallPrefabSide, vector, Quaternion.Euler(0, 0, 270)); break;
            //case '5': Instantiate(WallPrefabSide, vector, Quaternion.Euler(0, 0, 180)); break;
            //case '6': Instantiate(WallPrefabSide, vector, Quaternion.Euler(0, 0, 90)); break;

            case '7': Instantiate(WallPrefabConer, vector, Quaternion.identity); break;
            case '8': Instantiate(WallPrefabConer, vector, Quaternion.Euler(0, 0, 270)); break;
            case '9': Instantiate(WallPrefabConer, vector, Quaternion.Euler(0, 0, 180)); break;
            case 'a': Instantiate(WallPrefabConer, vector, Quaternion.Euler(0, 0, 90)); break;
            case 'b': Instantiate(CellPrefab, vector, Quaternion.identity); Instantiate(Bonus, new Vector3(vector.x, vector.y, -1), Quaternion.identity);break;

            case 'w': Instantiate(WinFieldPrefab, vector, Quaternion.identity); break;
            //case 'c': Instantiate(Bonus, vector, Quaternion.identity); Object.Instantiate(CellPrefab, vector, Quaternion.identity); break;
            //case 'd': Instantiate(Level, vector, Quaternion.identity); break;

            case 'x': Instantiate(CellPrefab, vector, Quaternion.identity); Instantiate(Enemy, new Vector3(vector.x, vector.y, -1), Quaternion.identity); break;
            //case 'z': Instantiate(CellPrefab, vector, Quaternion.identity);
            //    var p = Instantiate(Player, new Vector3(vector.x, vector.y, -1), Quaternion.identity);
            //    var c = Instantiate(new Camera(), new Vector3(vector.x, vector.y, -10), Quaternion.identity);
            //    CameraMoving cm = new CameraMoving();
            //    cm.Player = p;
            //    c.gameObject.AddComponent<CameraMoving>(); break;
        }
        //Instantiate(CellPrefab, vector, Quaternion.identity);
    }
}