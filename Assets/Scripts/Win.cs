using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public string Aim;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Aim);
    }

    void Update()
    {
        if (player != null)
        {
            if (Comparer.IsVectorEqual(transform.position, player.transform.position))
            {
                Debug.Log("----- Win -----");
                Time.timeScale = 0;
            }
        }
    }
}