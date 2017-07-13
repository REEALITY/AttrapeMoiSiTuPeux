﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchBalls : MonoBehaviour {

    public Text score;
    public GameObject Player;
    public ParticleSystem disapear;

    private int point = 0;
    private AudioSource ringSfx;

    private void Start()
    {
        score.text = "" + point;
        ringSfx = GetComponent<AudioSource>(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Filet")
        {
            Physics.IgnoreCollision(GetComponentInParent<Collider>(), GetComponent<Collider>());
        }
    }

     void OnTriggerEnter(Collider Balls)
     {
        if (Balls.gameObject.tag == "Balls")
        {
            point += 5;
            score.text = "" + point;
            disapear.Play(true);
            ringSfx.Play();
            Destroy(Balls.gameObject);
        }
        else if (Balls.gameObject.tag == "Calice")
        {
            point += 10;
            score.text = "" + point;
            disapear.Play(true);
            ringSfx.Play();
            Destroy(Balls.gameObject);
        }
        else if (Balls.gameObject.tag == "Bombe")
        {
            point -= 5;
            score.text = "" + point;
            disapear.Play(true);
            Destroy(Balls.gameObject);
        }
        else if (Balls.gameObject.tag == "Crane")
        {
            point -= 10;
            score.text = "" + point;
            disapear.Play(true);
            Destroy(Balls.gameObject);
        }
    }
}
