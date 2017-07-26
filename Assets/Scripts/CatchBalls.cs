using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchBalls : MonoBehaviour {

    public Text score;
    public GameObject Player;
    public ParticleSystem disapear;
    public AudioClip bad;
    public AudioClip good;
    static public int point = 0;

    private AudioSource sound;
    
    private void Start()
    {
        point = 0;
        score.text = "" + point;
        sound = GetComponent<AudioSource>();
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
            sound.clip = good;
            sound.Play();
            Destroy(Balls.gameObject);
        }
        else if (Balls.gameObject.tag == "Calice")
        {
            point += 10;
            score.text = "" + point;
            disapear.Play(true);
            sound.Play();
            Destroy(Balls.gameObject);
        }
        else if (Balls.gameObject.tag == "Bombe")
        {
            point -= 5;
            score.text = "" + point;
            disapear.Play(true);
            sound.clip = bad;
            sound.Play();
            Destroy(Balls.gameObject);
        }
    }
}
