using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BuildMap : MonoBehaviour
{
    public string path;
    // Start is called before the first frame update
    void Start()
    {
        //path = Application.dataPath + "/test";
        //var info = new DirectoryInfo(path);
        //var fileinfo = info.GetFiles();
        //foreach (var file in fileinfo)
        //{
        //    print(file);
        //}
        //WWW folder = new WWW(path);
        //print(folder.text);
        StreamReader reader = new StreamReader(path);
        string info = reader.ReadLine();
        print(info);
        //string[] spitInfo = info.Split(new char);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
