using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;
    public float tgame = 60.0f;
    public GameObject test;
    public Text[] Pseudo;
    public Text[] Grade;
    public Text[] Points;

    private Menu Menu;
    private CatchBalls CatchBalls;
    private string Pseudonyme;
    private int MyNewPoints;

    private enum States
    {
        timerOn, timerOff
    };
    private States myState;

    private void Start()
    {
        myState = States.timerOn;
        Pseudonyme = Menu.Pseudo;
    }

    private void Update()
    {
        if (myState == States.timerOn) { StartGame(); }
        else if (myState == States.timerOff) { EndGame(); }
    }

    void StartGame()
    {
        string data = "";

        timer.text = data + (int)tgame;
        tgame -= Time.deltaTime;
        if ((int)tgame == 0)
            myState = States.timerOff;
    }

    public void EndGame()
    {
        MyNewPoints = CatchBalls.point;
        test.SetActive(true);
        Debug.Log(Pseudonyme);
    }
}
