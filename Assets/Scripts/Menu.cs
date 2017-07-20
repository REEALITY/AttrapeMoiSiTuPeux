using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour {

    saveconfig sc;

    public InputField WritePseudo;
    public Text msgWelcome;
    static public string Pseudo;

    private void Update()
    {
        string data = "Welcome ";
        
        Pseudo = WritePseudo.text;
        msgWelcome.text = data + Pseudo;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Save(Pseudo);
            WritePseudo.gameObject.SetActive(false);
            //SceneManager.LoadScene(1);
        }
    }

    // Use this for initialization
    void Start()
    {
        sc = GetComponent<saveconfig>();
    }

    public void Save(string PlayerName)
    {
        Debug.Log(PlayerName);
        string filepath = sc.dataPath + "Pseudo.xml";

        XmlDocument Xmldoc = new XmlDocument();

        if (File.Exists(filepath))
        {
            Xmldoc.Load(filepath);

            XmlElement elmroot = Xmldoc.DocumentElement;
            //elmroot.RemoveAll();

            XmlElement elmnew = Xmldoc.CreateElement("player");

            XmlElement name = Xmldoc.CreateElement("name");
            name.InnerText = PlayerName;

            elmnew.AppendChild(name);

            elmroot.AppendChild(elmnew);

            Xmldoc.Save(filepath);

        }
    }
}
