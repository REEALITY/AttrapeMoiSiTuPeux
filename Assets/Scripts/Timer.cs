﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;
    public float tgame = 60.0f;
    public GameObject CanvasHighScore;
    public GameObject CanvasTimer;
    public Text[] Pseudo;
    public Text[] Grade;
    public Text[] Points;
    public int[] ScorePoints;

    private Menu Menu;
    private CatchBalls CatchBalls;
    private string Pseudonyme;
    private int MyNewPoints;
    private Projectiles Projectiles;

    private enum States
    {
        timerOn, timerOff, s0, s1, s2, s3, s4, s5, s6
    };
    private States myState;

    private void Start()
    {
        myState = States.timerOn;
        Pseudonyme = Menu.Pseudo;
        Points[0].text = "" + ScorePoints[0];
        Points[1].text = "" + ScorePoints[1];
        Points[2].text = "" + ScorePoints[2];
        Points[3].text = "" + ScorePoints[3];
        Points[4].text = "" + ScorePoints[4];
        Points[5].text = "" + ScorePoints[5];
        Points[6].text = "" + ScorePoints[6];

    }

    private void Update()
    {
        if (myState == States.timerOn) { StartGame(); }
        else if (myState == States.timerOff) { EndGame(); }
        else if (myState == States.s0) { HighScore0(); }
        else if (myState == States.s1) { HighScore1(); }
        else if (myState == States.s2) { HighScore2(); }
        else if (myState == States.s3) { HighScore3(); }
        else if (myState == States.s4) { HighScore4(); }
        else if (myState == States.s5) { HighScore5(); }
        else if (myState == States.s6) { HighScore6(); }
    }

    void StartGame()
    {
        string data = "";

        myState = States.timerOn;
        timer.text = data + (int)tgame;
        tgame -= Time.deltaTime;
        if ((int)tgame == 0)
            myState = States.timerOff;
    }

    public void EndGame()
    {
        MyNewPoints = CatchBalls.point;
        CanvasHighScore.SetActive(true);
        CanvasTimer.SetActive(false);
        MyHighScore();
    }

    private void MyHighScore()
    {        
        if (MyNewPoints >= ScorePoints[0]) { myState = States.s0; }
        else if (MyNewPoints >= ScorePoints[1]) { myState = States.s1; }
        else if (MyNewPoints >= ScorePoints[2]) { myState = States.s2; }
        else if (MyNewPoints >= ScorePoints[3]) { myState = States.s3; }
        else if (MyNewPoints >= ScorePoints[4]) { myState = States.s4; }
        else if (MyNewPoints >= ScorePoints[5]) { myState = States.s5; }
        else if (MyNewPoints <= ScorePoints[6] || MyNewPoints >= ScorePoints[6]) { myState = States.s6; }
    }

    private void HighScore0()
    {
        ScorePoints[0] = MyNewPoints;
        Pseudo[0].text = Pseudonyme;
        Points[0].text = "" + ScorePoints[0];
    }
    private void HighScore1()
    {
        ScorePoints[1] = MyNewPoints;
        Pseudo[1].text = Pseudonyme;
        Points[1].text = "" + ScorePoints[1];
    }
    private void HighScore2()
    {
        ScorePoints[2] = MyNewPoints;
        Pseudo[2].text = Pseudonyme;
        Points[2].text = "" + ScorePoints[2];
    }
    private void HighScore3()
    {
        ScorePoints[3] = MyNewPoints;
        Pseudo[3].text = Pseudonyme;
        Points[3].text = "" + ScorePoints[3];
    }
    private void HighScore4()
    {
        ScorePoints[4] = MyNewPoints;
        Pseudo[4].text = Pseudonyme;
        Points[4].text = "" + ScorePoints[4];
    }
    private void HighScore5()
    {
        ScorePoints[5] = MyNewPoints;
        Pseudo[5].text = Pseudonyme;
        Points[5].text = "" + ScorePoints[5];
    }
    private void HighScore6()
    {
        ScorePoints[6] = MyNewPoints;
        Pseudo[6].text = Pseudonyme;
        Points[6].text = "" + ScorePoints[6];
    }

    public void Reload()
    {
        tgame = 60.0f;
        StartGame();
    }
}
