using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /* checks collision if the Tag "food" hits floor
     it gets destroyed */
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Food")
        {
            Destroy(col.gameObject);
            Debug.Log("hit floor");
        }
        if (col.gameObject.tag == "bad")
        {
            Destroy(col.gameObject);
            Debug.Log("hit floor");
        }
    }


}
