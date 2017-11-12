using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        if (Player != null)
        {
            if (Comparer.IsVectorEqual(transform.position, Player.transform.position))
            {
                Debug.Log("----- Win -----");
            }
        }
    }
}
