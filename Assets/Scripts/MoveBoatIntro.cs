using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoatIntro : MonoBehaviour {

    public float MoveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
    }
}
