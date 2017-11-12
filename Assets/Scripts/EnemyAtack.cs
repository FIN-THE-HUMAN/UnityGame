using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour {

    public GameObject Player;
    private PlayerLife life;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("player");
        life = Player.GetComponent<PlayerLife>();
    }
	
	void Update () {
        if(Player != null)
        {
            if (Comparer.IsVectorEqual(transform.position, Player.transform.position))
            {
                if (life != null) life.ReceiveDamage();
            }
        }
	}
}