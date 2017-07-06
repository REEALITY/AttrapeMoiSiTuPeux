using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;

    private float t = 60.0f;

    private enum States
    {
        timerOn, timerOff
    };
    private States myState;

    private void Start()
    {
        myState = States.timerOn;
    }

    private void Update()
    {
        Debug.Log(myState);
        if (myState == States.timerOn) { StartGame(); }
        else if (myState == States.timerOff) { endGame(); }
    }

    void StartGame()
    {
        string data = "Temps restant : ";

        timer.text = data + (int)t;
        t -= Time.deltaTime;
        if ((int)t == 0)
            myState = States.timerOff;
    }

    void endGame()
    {
        Debug.Log("End Game");
    }
}
