using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour{

    public void Die()
    {
        Destroy(gameObject);
    }

    public void ReceiveDamage()
    {
        Die();
    }
    void Update()
    {

    }
}