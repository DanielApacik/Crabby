using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour {
    public float fallSpeed = 40.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
    }
}
