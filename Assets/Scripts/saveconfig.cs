using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveconfig : MonoBehaviour {

    public string dataPath;
    
	void Start () {
        dataPath = Application.dataPath;
        dataPath = dataPath.Replace("Assets", "Assets/Resources/");
    }
}