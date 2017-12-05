using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

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
                Debug.Log("IsVectorEqual");
                var bonusController = player.GetComponent<BonusController>();
                if (bonusController != null) bonusController.Collect();
                else Debug.Log("bonusController is NULL");
                Destroy(gameObject);
            }
        }
    }
}