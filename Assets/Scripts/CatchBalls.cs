using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchBalls : MonoBehaviour {

    public Text score;
    public GameObject Player;
    public ParticleSystem disapear;

    private int point = 0;

    private void Start()
    {
        score.text = "" + point;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
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
        }
        else if (Balls.gameObject.tag == "Calice")
        {
            point += 10;
            score.text = "" + point;
            disapear.Play(true);
        }
        else if (Balls.gameObject.tag == "Bombe")
        {
            point -= 5;
            score.text = "" + point;
            disapear.Play(true);
        }
        else if (Balls.gameObject.tag == "Crane")
        {
            point -= 10;
            score.text = "" + point;
            disapear.Play(true);
        }
    }
}
