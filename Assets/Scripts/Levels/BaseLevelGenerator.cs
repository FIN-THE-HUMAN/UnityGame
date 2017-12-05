using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BaseLevelGenerator : MonoBehaviour {

    public string FileName;
    string content;
    public GameObjectDictionary gameObjectDictionary;

    void Start () {
        TextAsset textAssets = (TextAsset)Resources.Load(FileName);
        DrawMap(textAssets.text);
    }

    int GetLineSize(string text)
    {
        int result = 0;
        foreach(char c in text)
        {
            if (c == '\n') break;
            result++;
        }
        return result;
    }

    Vector2Int GetMapSize(string text)
    {
        int x = GetLineSize(text);
        int y = 0;

        foreach(char c in text)
        {
            if (c == '\n')  y++;
        }
        y++;
        return new Vector2Int(x,y);
    }

    void DrawMap(string text)
    {
        Vector2Int size = GetMapSize(text);
        int x = 0;
        int y = 0;
        foreach (char c in text)
        {
            if (c == '\n')
            {
                y++;
                x = 0;
            }
            else
            {
                gameObjectDictionary.InstantiateFromChar(c, new Vector3(x - size.X/2, - (y - size.Y/2), 0));
                x++;
            }
        }
    }
}