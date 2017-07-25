using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour {

    public saveconfig sc;

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
            WritePseudo.gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }

    // Use this for initialization
    void Start()
    {
        sc = GetComponent<saveconfig>();
    }
}
