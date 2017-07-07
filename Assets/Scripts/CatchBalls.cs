using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchBalls : MonoBehaviour {

    public Text score;
    private int point = 0;

    private void Start()
    {
        score.text = "Score : " + point;
    }

    void OnTriggerEnter(Collider Balls)
    {
        if (Balls.gameObject.tag == "Balls")
        {
            point += 5;
            score.text = "Score : " + point;
            Debug.Log("Filet activated");
        }
        else if (Balls.gameObject.tag == "Bombe")
        {
            point -= 10;
            score.text = "Score : " + point;
            Debug.Log("Filet activated");
        }
    }
}
