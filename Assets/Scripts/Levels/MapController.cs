﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class MapController : MonoBehaviour {

	public GameObject CellPrefab;
    public GameObject WallPrefab;
    public GameObject WinFieldPrefab;

	private GameObject[][] Map;

	private int MaxSize(string[] text){
		int max = 0;
		foreach(string s in text){
			if (s.Length > max)	max = s.Length;
		}
		return max;
	}

	private bool IsTextValid(int size, string[] text){
		foreach(string s in text){
			if (s.Length != size) return false;
		}
		return true;
	}

	int[][] GetMatrix(Vector2Int size){
		int[][] matrix = new int[size.Y][];
		for (int i = 0; i < size.Y; i++) {
			matrix[i] = new int[size.X];
		}
		return matrix;
	}

    GameObject GetBlockFromIndex(int index)
    {
        switch (index)
        {
            case 0: return CellPrefab;
            case 1: return WallPrefab;
            case 2: return WinFieldPrefab;
        }
        return CellPrefab;
    }

    GameObject[][] DrawMap(int[][] matrix, Vector2Int size){
        GameObject[][] map = new GameObject[size.Y][];
		for (int i = 0; i < size.Y; i++) {
			map[i] = new GameObject[size.X];
			for (int j = 0; j < size.X; j++) {
				map[i][j] = Instantiate(GetBlockFromIndex(matrix[i][j]), new Vector3(j - size.X/2,i - size.Y/2, 0), Quaternion.identity) as GameObject;
			}
		}
        return map;
	}

	int[][] InitializeMapMatrixByText(string[] text){
		Vector2Int size = GetMapSize(text);
		int[][] result = GetMatrix(size);
		int zeroSize = 48;        
		for(int i = 0; i < size.Y; i++)
		{
			for(int j = 0; j < size.X; j++)
			{
				result[i][j] = Convert.ToInt32(text[i][j]);
				result[i][j] -= zeroSize;
			}
		}
		return result;
	}

	Vector2Int GetMapSize(string[] text){
		int xSize = MaxSize(text);
		int ySize = text.Length;
		Vector2Int result = new Vector2Int (xSize, ySize);
		return result;
	}

	string[] GetMapTextFromFile(string path){
		FileInfo f = new FileInfo (path); 
		if (!f.Exists) {
			Debug.Log ("нет файла *-----------------* "); // throw ThereIsNoFileException
			return null;
		}
		return File.ReadAllLines(path);
	}
    
	void Start () {
		string[] textFromFile = GetMapTextFromFile("map.txt");
		int[][] matrix = InitializeMapMatrixByText (textFromFile);
		Map = DrawMap(matrix, GetMapSize(textFromFile));
	}
	 
	void Update () {

	}
}