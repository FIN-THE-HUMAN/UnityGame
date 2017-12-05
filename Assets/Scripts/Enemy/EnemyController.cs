using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class EnemyController : MonoBehaviour {

	public int XMatrixSize;
	public int YMatrixSize;
	public int EnemyCount;
	public GameObject EnemyPrefab;

	private List<GameObject> enemies;

	void Start() {
		enemies = new List<GameObject>();
		System.Random random = new System.Random();

		for (int i = 0; i < EnemyCount; i++) {
			GameObject o = Instantiate(EnemyPrefab, 
				new Vector3(random.Next(-XMatrixSize / 2, XMatrixSize / 2),random.Next(-YMatrixSize / 2, YMatrixSize / 2), -1), 
				Quaternion.identity) as GameObject;
			enemies.Add(o);
		}
	}
}