using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class HandleText : MonoBehaviour {

    private Menu menu;

    void Load()
    {
        XmlDocument Xmldoc = new XmlDocument();
        string filepath = menu.sc.dataPath + "highscore.xml";

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
                        Debug.Log("player : " + Item.InnerText);
                    }
                    if (Item.Name == "timerace")
                    {
                        Debug.Log("time : " + Item.InnerText);
                    }
                    if (Item.Name == "timerun")
                    {
                        Debug.Log("timerun : " + Item.InnerText);
                    }
                }
            }
        }
    }
}
