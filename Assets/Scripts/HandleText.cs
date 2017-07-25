using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class HandleText : MonoBehaviour {

    static public int[] scorepoints = new int[50] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,};
    static public string[] pseudoboard = new string[50] { "", "", "", "", "", "", "", "", "", "",
                                                          "", "", "", "", "", "", "", "", "", "",
                                                          "", "", "", "", "", "", "", "", "", "",
                                                          "", "", "", "", "", "", "", "", "", "",
                                                          "", "", "", "", "", "", "", "", "", "",};
    static public saveconfig sc;
    static public int i = 0;

    public void Start()
    {
        sc = GetComponent<saveconfig>();
    }

    static public void LoadPlayer()
    {
        XmlDocument Xmldoc = new XmlDocument();
        string filepath = sc.dataPath + "Player.xml";

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
                        pseudoboard[i] = Item.InnerText;
                    }
                    else if (Item.Name == "score")
                    {
                        scorepoints[i] = GetInt(Item.InnerText);
                    }
                }
                i++;
            }
        }
    }

    static public int GetInt(string stringValue)
    {
        int result = 0;
        int.TryParse(stringValue, out result);
        return result;
    }
}
