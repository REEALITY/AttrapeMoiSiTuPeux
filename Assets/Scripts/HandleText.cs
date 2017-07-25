using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class HandleText : MonoBehaviour {

    static public int[] scorepoints = new int[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    static public string[] pseudoboard = new string[10] { "", "", "", "", "", "", "", "", "", "" };
    static public saveconfig sc;
    static private int i = 0;
    static private int i2 = 0;

    public void Start()
    {
        sc = GetComponent<saveconfig>();
    }

    static public void LoadPseudo()
    {
        XmlDocument Xmldoc = new XmlDocument();
        string filepath = sc.dataPath + "Pseudo.xml";

        if (File.Exists(filepath))
        {
            Xmldoc.Load(filepath);

            XmlNodeList listscore = Xmldoc.GetElementsByTagName("player");

            foreach (XmlNode info in listscore)
            {
                XmlNodeList content = info.ChildNodes;
                foreach (XmlNode Item in content)
                {
                    if (Item.Name == "name")
                    {
                        pseudoboard[i2] = Item.InnerText;
                        i2++;
                    }
                }
            }
        }
    }

    static public int GetInt(string stringValue)
    {
        int result = 0;
        int.TryParse(stringValue, out result);
        return result;
    }

    static public void LoadScore()
    {
        XmlDocument Xmldoc = new XmlDocument();
        string filepath = sc.dataPath + "Score.xml";

        if (File.Exists(filepath))
        {
            Xmldoc.Load(filepath);

            XmlNodeList listscore = Xmldoc.GetElementsByTagName("player");

            foreach (XmlNode info in listscore)
            {
                XmlNodeList content = info.ChildNodes;
                foreach (XmlNode Item in content)
                {
                    if (Item.Name == "score")
                    {
                        scorepoints[i] = GetInt(Item.InnerText);
                        i++;
                    }
                }
            }
        }
    }
}
