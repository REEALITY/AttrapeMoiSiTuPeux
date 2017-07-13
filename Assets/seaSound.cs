using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seaSound : MonoBehaviour {

    private AudioSource SeaSFX;

    // Use this for initialization
    void Start () {
        SeaSFX = GetComponent<AudioSource>();
        SeaSFX.Play();
    }
}
