using System.Collections;
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
    public AudioSource[] Audio;
    public AudioClip[] VoiceSource;

    private Menu Menu;
    private CatchBalls CatchBalls;
    private string Pseudonyme;
    private int MyNewPoints;
    private Projectiles Projectiles;

    private enum States
    {
        timerOn, timerOff, s0, s1, s2, s3, s4, s5, s6, s7, s8, s9
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
        else if (myState == States.s0) { HighScore0(); }
        else if (myState == States.s1) { HighScore1(); }
        else if (myState == States.s2) { HighScore2(); }
        else if (myState == States.s3) { HighScore3(); }
        else if (myState == States.s4) { HighScore4(); }
        else if (myState == States.s5) { HighScore5(); }
        else if (myState == States.s6) { HighScore6(); }
        else if (myState == States.s7) { HighScore7(); }
        else if (myState == States.s8) { HighScore8(); }
        else if (myState == States.s9) { HighScore9(); }
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
        Audio[0].clip = VoiceSource[0];
        Audio[1].clip = VoiceSource[1];
        Audio[2].clip = VoiceSource[2];
        MyNewPoints = CatchBalls.point;
        CanvasHighScore.SetActive(true);
        CanvasTimer.SetActive(false);
        if (MyNewPoints >= 250) {
            Audio[0].volume = 1;
            Audio[0].Play();
            //Audio[0].Stop();
        }
        else if (MyNewPoints <= 0) {
            Audio[1].volume = 1;
            Audio[1].Play();
            //Audio[1].Stop();
        }
        else {
            Audio[2].volume = 1;
            Audio[2].Play();
           // Audio[2].Stop();
        }
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
        else if (MyNewPoints >= ScorePoints[6]) { myState = States.s6; }
        else if (MyNewPoints >= ScorePoints[7]) { myState = States.s7; }
        else if (MyNewPoints >= ScorePoints[8]) { myState = States.s8; }
        else if (MyNewPoints >= ScorePoints[9]) { myState = States.s9; }
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
    private void HighScore7()
    {
        ScorePoints[7] = MyNewPoints;
        Pseudo[7].text = Pseudonyme;
        Points[7].text = "" + ScorePoints[7];
    }
    private void HighScore8()
    {
        ScorePoints[8] = MyNewPoints;
        Pseudo[8].text = Pseudonyme;
        Points[8].text = "" + ScorePoints[8];
    }
    private void HighScore9()
    {
        ScorePoints[9] = MyNewPoints;
        Pseudo[9].text = Pseudonyme;
        Points[9].text = "" + ScorePoints[9];
    }

    public void Reload()
    {
        tgame = 60.0f;
        StartGame();
    }
}
