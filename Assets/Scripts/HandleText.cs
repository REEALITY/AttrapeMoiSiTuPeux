using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class HandleText : MonoBehaviour
{
    public TextAsset pseudo;
    public Text uiPseudo;

    private void Start()
    {
        string data = pseudo.text;
        string path = "//BombPirates/pseudo";

        ParseXmlFile_first(data, path);
    }

    void ParseXmlFile_first(string xmlData, string path)
    {
        string totVal = "";

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));

        XmlNodeList myNodeList = xmlDoc.SelectNodes(path);
        foreach (XmlNode node in myNodeList)
        {
            XmlNode pseudo = node.FirstChild;
            totVal = pseudo.InnerXml + "\n\n";
            uiPseudo.text = totVal;
        }
    }
}
