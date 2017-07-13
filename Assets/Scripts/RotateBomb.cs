using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBomb : MonoBehaviour {

    private float speed;

    private void Start()
    {
        speed = Random.Range(100, 300);
    }

    private void Update () {
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
    }
}