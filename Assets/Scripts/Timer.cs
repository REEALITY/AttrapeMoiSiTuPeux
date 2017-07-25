using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class Timer : MonoBehaviour {

    public Text timer;
    public float tgame = 60.0f;
    public GameObject CanvasHighScore;
    public GameObject CanvasTimer;
    public Text[] Pseudo;
    public Text[] Grade;
    public Text[] Points;
    public AudioSource[] Audio;
    public AudioClip[] VoiceSource;
    public saveconfig sc;

    private Menu Menu;
    private CatchBalls CatchBalls;
    private string Pseudonyme;
    private int MyNewPoints;
    private Projectiles Projectiles;
    private HandleText test;
    private int[] mySortScore;

    private enum States
    {
        timerOn, timerOff, s0, s1, s2, s3, s4, s5, s6, s7, s8, s9
    };
    private States myState;

    private void Start()
    {
        sc = GetComponent<saveconfig>();
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
        Debug.Log(myState);
    }

    void StartGame()
    {
        string data = "";

        myState = States.timerOn;
        timer.text = data + (int)tgame;
        tgame -= Time.deltaTime;
        if ((int)tgame == 0)
        {
            MyNewPoints = CatchBalls.point;
            SaveScore(MyNewPoints);
        }
    }

    public void EndGame()
    {
        //mySortScore = HandleText.scorepoints;
        //Debug.Log(mySortScore[0]);

        Audio[0].clip = VoiceSource[0];
        Audio[1].clip = VoiceSource[1];
        Audio[2].clip = VoiceSource[2];
        CanvasHighScore.SetActive(true);
        CanvasTimer.SetActive(false);
        HandleText.LoadScore();
        HandleText.LoadPseudo();
        System.Array.Sort(HandleText.scorepoints);
        Debug.Log(HandleText.scorepoints[0]);
        Debug.Log(HandleText.scorepoints[1]);
        Debug.Log(HandleText.scorepoints[2]);
        Debug.Log(HandleText.scorepoints[3]);
        Debug.Log(HandleText.scorepoints[4]);
        Debug.Log(HandleText.scorepoints[5]);
        Debug.Log(HandleText.scorepoints[6]);
        Debug.Log(HandleText.scorepoints[7]);
        Debug.Log(HandleText.scorepoints[8]);
        Debug.Log(HandleText.scorepoints[9]);
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
        if (MyNewPoints >= HandleText.scorepoints[0]) { myState = States.s0; }
        else if (MyNewPoints >= HandleText.scorepoints[1]) { myState = States.s1; }
        else if (MyNewPoints >= HandleText.scorepoints[2]) { myState = States.s2; }
        else if (MyNewPoints >= HandleText.scorepoints[3]) { myState = States.s3; }
        else if (MyNewPoints >= HandleText.scorepoints[4]) { myState = States.s4; }
        else if (MyNewPoints >= HandleText.scorepoints[5]) { myState = States.s5; }
        else if (MyNewPoints >= HandleText.scorepoints[6]) { myState = States.s6; }
        else if (MyNewPoints >= HandleText.scorepoints[7]) { myState = States.s7; }
        else if (MyNewPoints >= HandleText.scorepoints[8]) { myState = States.s8; }
        else if (MyNewPoints >= HandleText.scorepoints[9]) { myState = States.s9; }
                 
    }

    private void HighScore0()
    {
        HandleText.scorepoints[0] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }
    private void HighScore1()
    {
        HandleText.scorepoints[1] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }
    private void HighScore2()
    {
        HandleText.scorepoints[2] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }
    private void HighScore3()
    {
        HandleText.scorepoints[3] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }
    private void HighScore4()
    {
        HandleText.scorepoints[4] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }
    private void HighScore5()
    {
        HandleText.scorepoints[5] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }
    private void HighScore6()
    {
        HandleText.scorepoints[6] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }
    private void HighScore7()
    {
        HandleText.scorepoints[7] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }
    private void HighScore8()
    {
        HandleText.scorepoints[8] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }
    private void HighScore9()
    {
        HandleText.scorepoints[9] = MyNewPoints;
        Pseudo[0].text = HandleText.pseudoboard[0];
        Pseudo[1].text = HandleText.pseudoboard[1];
        Pseudo[2].text = HandleText.pseudoboard[2];
        Pseudo[3].text = HandleText.pseudoboard[3];
        Pseudo[4].text = HandleText.pseudoboard[4];
        Pseudo[5].text = HandleText.pseudoboard[5];
        Pseudo[6].text = HandleText.pseudoboard[6];
        Pseudo[7].text = HandleText.pseudoboard[7];
        Pseudo[8].text = HandleText.pseudoboard[8];
        Pseudo[9].text = HandleText.pseudoboard[9];
        Points[0].text = "" + HandleText.scorepoints[0];
        Points[1].text = "" + HandleText.scorepoints[1];
        Points[2].text = "" + HandleText.scorepoints[2];
        Points[3].text = "" + HandleText.scorepoints[3];
        Points[4].text = "" + HandleText.scorepoints[4];
        Points[5].text = "" + HandleText.scorepoints[5];
        Points[6].text = "" + HandleText.scorepoints[6];
        Points[7].text = "" + HandleText.scorepoints[7];
        Points[8].text = "" + HandleText.scorepoints[8];
        Points[9].text = "" + HandleText.scorepoints[9];
    }

    public void SaveScore(int MyScore)
    {
        string filepath = sc.dataPath + "Score.xml";

        XmlDocument Xmldoc = new XmlDocument();

        if (File.Exists(filepath))
        {
            Xmldoc.Load(filepath);

            XmlElement elmroot = Xmldoc.DocumentElement;
            //elmroot.RemoveAll();

            XmlElement elmnew = Xmldoc.CreateElement("player");

            XmlElement score = Xmldoc.CreateElement("score");
            score.InnerText = MyScore.ToString();
            elmnew.AppendChild(score);

            elmroot.AppendChild(elmnew);

            Xmldoc.Save(filepath);

            myState = States.timerOff;

        }
    }
}
