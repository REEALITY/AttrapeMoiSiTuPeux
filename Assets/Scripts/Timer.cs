using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text timer;
    public float tgame = 60.0f;
    public GameObject CanvasHighScore;
    public GameObject CanvasTimer;
    public Text[] Pseudo;
    public Text[] Grade;
    public Text[] Points;
    public AudioSource[] Audio;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
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
            SavePlayer(Pseudonyme, MyNewPoints);
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
            while (i != 499)
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
        CanvasHighScore.SetActive(true);
        CanvasTimer.SetActive(false);
        HandleText.LoadPlayer();
        MySwap();
        if (MyNewPoints >= 150) {
            Audio[0].gameObject.SetActive(true);
        }
        else if (MyNewPoints > 0 &&
                 MyNewPoints < 150) { 
            Audio[1].gameObject.SetActive(true);
        }
        else if (MyNewPoints < 0) {
            Audio[2].gameObject.SetActive(true);
        }
        myState = States.HighScore;
    }

    private void MyHighScore()
    {
        for (int i = 0; i <= 9; i++)
        {
            Pseudo[i].text = HandleText.pseudoboard[i];
            Points[i].text = "" + HandleText.scorepoints[i];
        }

        for (int i = 0; i <= 499; i++)
        { 
            if (HandleText.scorepoints[i] >= 180)
            {
                Grade[i].text = "Capitaine";
            }
            else if (HandleText.scorepoints[i] > 150)
            {
                Grade[i].text = "Corsaire";
            }
            else if (HandleText.scorepoints[i] > 75)
            {
                Grade[i].text = "Marin";
            }
            else if (HandleText.scorepoints[i] > 60)
            {
                Grade[i].text = "Navigateur";
            }
            else if (HandleText.scorepoints[i] > 50)
            {
                Grade[i].text = "Second maître";
            }
            else if (HandleText.scorepoints[i] > 30)
            {
                Grade[i].text = "Cannonier";
            }
            else
                Grade[i].text = "Moussaillon";
        }
    }

    public void SavePlayer(string PlayerPseudo, int MyScore)
    {
        string levelFilePath = Application.persistentDataPath + "/Player.xml";
        Debug.Log(levelFilePath);
        XmlDocument Xmldoc = new XmlDocument();

        if (File.Exists(levelFilePath))
        {
            Xmldoc.Load(levelFilePath);

            XmlElement elmroot = Xmldoc.DocumentElement;

            XmlElement elmnew = Xmldoc.CreateElement("player");

            XmlElement name = Xmldoc.CreateElement("name");
            name.InnerText = PlayerPseudo; 
            elmnew.AppendChild(name);

            XmlElement score = Xmldoc.CreateElement("score");
            score.InnerText = MyScore.ToString();
            elmnew.AppendChild(score);

            elmroot.AppendChild(elmnew);

            Xmldoc.Save(levelFilePath);

            myState = States.timerOff;

        }
    }
}