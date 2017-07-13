using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartpos : MonoBehaviour {

    private float x;
    private float y;
    private float z;
    // Use this for initialization
    void Start () {
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(x, y, z);
	}
}
