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
        timerOn, timerOff, HighScore
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
        else if (myState == States.HighScore) { MyHighScore(); }
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
            SavePlayer(Pseudonyme, MyNewPoints, sc.dataPath);
        }
    }

    private void MySwap()
    {
        int i = 0;
        int temp = 0;
        int stop = 1;
        string TS = "";

        while (stop != 0)
        {
            stop = 0;
            i = 0;
            while (i != 49)
            {
                if (HandleText.scorepoints[i] < HandleText.scorepoints[i + 1])
                {
                    temp = HandleText.scorepoints[i];
                    TS = HandleText.pseudoboard[i];
                    HandleText.scorepoints[i] = HandleText.scorepoints[i + 1];
                    HandleText.pseudoboard[i] = HandleText.pseudoboard[i + 1];
                    HandleText.scorepoints[i + 1] = temp;
                    HandleText.pseudoboard[i + 1] = TS;

                    stop = 1;
                }
                i++;
            }
        }
    }

    public void EndGame()
    {
        Audio[0].clip = VoiceSource[0];
        Audio[1].clip = VoiceSource[1];
        Audio[2].clip = VoiceSource[2];
        CanvasHighScore.SetActive(true);
        CanvasTimer.SetActive(false);
        HandleText.LoadPlayer();
        MySwap();
        //System.Array.Sort(HandleText.scorepoints);
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
        myState = States.HighScore;
        //MyHighScore();
    }

    private void MyHighScore()
    {
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

        for (int i = 0; i <= 49; i++)
        { 
            if (HandleText.scorepoints[i] >= 200)
            {
                Grade[i].text = "Capitaine";
            }
            else if (HandleText.scorepoints[i] > 150)
            {
                Grade[i].text = "Corsaire";
            }
            else if (HandleText.scorepoints[i] > 100)
            {
                Grade[i].text = "Marin";
            }
            else if (HandleText.scorepoints[i] > 75)
            {
                Grade[i].text = "Navigateur";
            }
            else if (HandleText.scorepoints[i] > 50)
            {
                Grade[i].text = "Second maître";
            }
            else if (HandleText.scorepoints[i] > 25)
            {
                Grade[i].text = "Cannonier";
            }
            else if (HandleText.scorepoints[i] > 0)
            {
                Grade[i].text = "Moussaillon";
            }
        }
    }

    public void SavePlayer(string PlayerPseudo, int MyScore, string filepath)
    {
        filepath = filepath + "Player.xml";
        Debug.Log(filepath);
        XmlDocument Xmldoc = new XmlDocument();

        if (File.Exists(filepath))
        {
            //TextAsset textAsset = (TextAsset)Resources.Load(filepath, typeof(TextAsset));
            Xmldoc.Load(filepath);

            XmlElement elmroot = Xmldoc.DocumentElement;
            //elmroot.RemoveAll();

            XmlElement elmnew = Xmldoc.CreateElement("player");

            XmlElement name = Xmldoc.CreateElement("name");
            name.InnerText = PlayerPseudo; 
            elmnew.AppendChild(name);

            XmlElement score = Xmldoc.CreateElement("score");
            score.InnerText = MyScore.ToString();
            elmnew.AppendChild(score);

            elmroot.AppendChild(elmnew);

            Xmldoc.Save(filepath);

            myState = States.timerOff;

        }
    }
}
