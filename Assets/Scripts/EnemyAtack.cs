using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour {

    public string Aim;

    private PlayerLife life;
    private GameObject player;

    void Start () {
        player = GameObject.FindGameObjectWithTag(Aim);
        life = player.GetComponent<PlayerLife>();
    }
	
	void Update () {
        if(player != null)
        {
            if (Comparer.IsVectorEqual(transform.position, player.transform.position))
            {
                if (life != null) life.ReceiveDamage();
            }
        }
	}
}