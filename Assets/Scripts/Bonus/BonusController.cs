using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {

    private int collectedBonuses;
    public GUIText gUIText;

    public int GetBonuses()
    {
        return collectedBonuses;
    }

    public void Collect()
    {
        collectedBonuses++;
        Debug.Log(collectedBonuses.ToString());
        gUIText.text = collectedBonuses.ToString();
    }

	// Use this for initialization
	void Start () {
        collectedBonuses = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
