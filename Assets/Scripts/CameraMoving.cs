using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour {
    public float speed = 3.0f;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("player");
    }
	
	// Update is called once per frame
	void Update () {
        if(Player != null)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        }
    }
}
